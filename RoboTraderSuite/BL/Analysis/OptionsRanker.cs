using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Analysis
{
    public class RankedOption
    {
        public OptionData Option { get; set; }
        public double Rank { get; set; }

        public RankedOption(OptionData option, double rank)
        {
            Option = option;
            Rank = rank;
        }
    }
    public class OptionsRanker
    {
        private readonly double _minimalTheta;
        private readonly double _minDistanceFromUnlFraction;
        private readonly int _minExpiryDays;
        private readonly int _maxExpiryDays;
        private readonly double SMALL_NUMBER = 0.000001;
        private readonly double _thetaWeight;
        private readonly double _vegaWeight;
        private readonly double _expiryWeight;

        public OptionsRanker(double minimalTheta, double minDistanceFromUNLPercent,
            int minExpiryDays, int maxExpiryDays,double thetaWeight = 10, 
            double vegaWeight = 2, double expiryWeight = 1)
        {
            _minimalTheta = minimalTheta;
            _minDistanceFromUnlFraction = minDistanceFromUNLPercent/100.0;
            _minExpiryDays = minExpiryDays;
            _maxExpiryDays = maxExpiryDays;
            _thetaWeight = thetaWeight;
            _vegaWeight = vegaWeight;
            _expiryWeight = expiryWeight;
        }

        public IEnumerable<RankedOption> RankOptions(IEnumerable<OptionData> options)
        {
            var filtered = FilterPreconditions(options);
            return RankOptionsInner(filtered);

        }

        public IEnumerable<OptionData> FilterPreconditions(IEnumerable<OptionData> options)
        {
            return options.Where(a => FilterByTheta(a) && FilterByStrike(a) && FilterByExpiry(a));
        }

        private bool FilterByTheta(OptionData option)
        {
            return option.Theta > _minimalTheta;
        }
        private bool FilterByStrike(OptionData option)
        {
            bool isVialbleCall = option.OptionContract.OptionType == EOptionType.Call && 
                option.OptionContract.Strike > option.UnderlinePrice*(1 + _minDistanceFromUnlFraction);
            bool isViablePut = option.OptionContract.OptionType == EOptionType.Put &&
                option.OptionContract.Strike < option.UnderlinePrice * (1 - _minDistanceFromUnlFraction);

            return isVialbleCall || isViablePut;
        }

        private bool FilterByExpiry(OptionData optionData)
        {
            return optionData.DaysLeft >= _minExpiryDays &&
                   optionData.DaysLeft <= _maxExpiryDays;
        }

        private IEnumerable<RankedOption> RankOptionsInner(IEnumerable<OptionData> filtered)
        {
            return filtered.Select(o =>
            {
                double rank = ThetaRank(o)*_thetaWeight + VegaRank(o)*_vegaWeight + ExpiryRank(o)*_expiryWeight;
                return new RankedOption(o, rank);
            }).OrderByDescending(a => a.Rank);
        }

        private double ThetaRank(OptionData option)
        {
            double maxReasonableTheta = 100;
            double theta = option.Theta;
            if (theta == 0.0)
            {
                theta = SMALL_NUMBER;
            }
            return theta / maxReasonableTheta;
        }

        private double VegaRank(OptionData option)
        {
            double maxReasonableVega = 100;
            double vega = option.Vega;
            if (vega == 0.0)
            {
                vega = SMALL_NUMBER;
            }
            return Math.Abs(vega / maxReasonableVega - 1);
        }

        private double ExpiryRank(OptionData option)
        {
            double maxReasonableExpiryDays = 365;
            return Math.Abs(option.DaysLeft/maxReasonableExpiryDays-1);
        }
    }


}

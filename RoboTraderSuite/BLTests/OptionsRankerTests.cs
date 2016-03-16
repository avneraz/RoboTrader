using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Infra.Enum;
using NUnit.Framework;
using TNS.API.ApiDataObjects;
using TNS.BL.Analysis;

namespace BLTests
{
    [TestFixture]
    public class OptionsRankerTests
    {
        private OptionsRanker _ranker;
        private const double MINIMAL_THETA = 2;
        private double MINIMAL_DIS_UNL = 10;
        private int MIN_EXPIRY_DAYS = 30;
        private int MAX_EXPIRY_DAYS = 60;

        [SetUp]
        public void Init()
        {
            _ranker = new OptionsRanker(MINIMAL_THETA, MINIMAL_DIS_UNL, MIN_EXPIRY_DAYS, MAX_EXPIRY_DAYS);
        }

        private OptionData GenerateOptionInPreconditions(EOptionType optionType)
        {
            double theta = MINIMAL_THETA + 1;
            DateTime expiry = DateTime.Now.Add(TimeSpan.FromDays(MIN_EXPIRY_DAYS + 1));
            double strike;
            double underline = 100;
            if (optionType == EOptionType.Call)
            {
                strike = underline*(1 + MINIMAL_DIS_UNL/100) + 10;
            }
            else
            {
                strike = underline*(1 - MINIMAL_DIS_UNL/100) - 10;
            }
            var optionContract = new OptionContract("AAPL", expiry, optionType)
            {
                Strike = strike
            };
            var option = new OptionData()
            {
                UnderlinePrice = underline,
                Theta = theta,
                OptionContract = optionContract
            };
            return option;
        }

        public void TestPreconditions(List<OptionData> expected,
            List<OptionData> notExpected)
        {
            var options = expected.Concat(notExpected);
            var res = _ranker.RankOptions(options);
            Assert.AreEqual(expected.Count(), res.Count());
            var optionsRes = res.Select(a => a.Option);
            CollectionAssert.IsSubsetOf(expected, optionsRes);
            CollectionAssert.IsNotSubsetOf(notExpected, optionsRes);
        }

        [Test]
        public void FilterByThetaTest()
        {
            var notExpectedObj = GenerateOptionInPreconditions(EOptionType.Call);
            notExpectedObj.Theta = MINIMAL_THETA - 1;
            var notExpectedList = new List<OptionData>() {notExpectedObj};
            var expectedObj = GenerateOptionInPreconditions(EOptionType.Put);
            expectedObj.Theta = MINIMAL_THETA + 1;
            var expectedList = new List<OptionData>() { expectedObj };
            TestPreconditions(expectedList, notExpectedList);
        }

        [Test]
        public void FilterByUnlTest()
        {

            var notExpectedObj = GenerateOptionInPreconditions(EOptionType.Put);
            notExpectedObj.OptionContract.Strike = 100;
            notExpectedObj.UnderlinePrice = 10;
            var notExpectedObj2 = GenerateOptionInPreconditions(EOptionType.Call);
            notExpectedObj2.OptionContract.Strike = 100;
            notExpectedObj2.UnderlinePrice = 1000;

            var notExpectedList = new List<OptionData>() { notExpectedObj, notExpectedObj2 };
            var expectedObj = GenerateOptionInPreconditions(EOptionType.Call);
            expectedObj.OptionContract.Strike = 100;
            expectedObj.UnderlinePrice = 10;

            var expectedObj2 = GenerateOptionInPreconditions(EOptionType.Put);
            expectedObj2.OptionContract.Strike = 10;
            expectedObj2.UnderlinePrice = 100;

            var expectedList = new List<OptionData>() { expectedObj };
            TestPreconditions(expectedList, notExpectedList);
        }

        [Test]
        public void FilterByExpiryRangeTest()
        {

            var notExpectedObj = GenerateOptionInPreconditions(EOptionType.Call);
            notExpectedObj.OptionContract.Expiry = DateTime.Now.Add(TimeSpan.FromDays(MAX_EXPIRY_DAYS + 2));
            var notExpectedObj2 = GenerateOptionInPreconditions(EOptionType.Call);
            notExpectedObj2.OptionContract.Expiry = DateTime.Now.Add(TimeSpan.FromDays(MIN_EXPIRY_DAYS - 2));
            var notExpectedList = new List<OptionData>() { notExpectedObj, notExpectedObj2 };
            var expectedObj = GenerateOptionInPreconditions(EOptionType.Put);
            expectedObj.OptionContract.Expiry = DateTime.Now.Add(TimeSpan.FromDays(MIN_EXPIRY_DAYS + 2));
            var expectedObj2 = GenerateOptionInPreconditions(EOptionType.Put);
            expectedObj2.OptionContract.Expiry = DateTime.Now.Add(TimeSpan.FromDays(MAX_EXPIRY_DAYS - 2));
            var expectedList = new List<OptionData>() { expectedObj , expectedObj2 };
            TestPreconditions(expectedList, notExpectedList);
        }

        [Test]
        public void RankTest()
        {
            //option1 is the best, after that option2 has higher vega, so it's wrose than 1
            //and then option3 is the worst, becaue also the expiry is further
            var option1 = GenerateOptionInPreconditions(EOptionType.Call);
            option1.Theta = 50;
            option1.Vega = 0;
            var option2 = GenerateOptionInPreconditions(EOptionType.Call);
            option2.Theta = 50;
            option2.Vega = 2;
            var option3 = GenerateOptionInPreconditions(EOptionType.Call);
            option3.Theta = 50;
            option3.Vega = 2;
            option3.OptionContract.Expiry = option3.OptionContract.Expiry.Add(TimeSpan.FromDays(1));
            var res = _ranker.RankOptions(new List<OptionData>() {option3, option2, option1});
            var optionRes = res.Select(a=> a.Option).ToList();
            Assert.AreEqual(option1, optionRes[0]);
            Assert.AreEqual(option2, optionRes[1]);
            Assert.AreEqual(option3, optionRes[2]);

        }


    }
}

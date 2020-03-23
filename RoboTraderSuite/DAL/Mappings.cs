using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Infra;
using Infra.Enum;
using Infra.Global;
using TNS.API.ApiDataObjects;

namespace DAL
{

    #region Component Map
    public class PositionsSummaryDataComponent : ComponentMap<PositionsSummaryData>
    {
        public PositionsSummaryDataComponent()
        {
            Map(x => x.DeltaTotal);
            Map(x => x.GammaTotal);
            Map(x => x.ThetaTotal);
            Map(x => x.VegaTotal);
            Map(x => x.MarketValue);
            Map(x => x.CostTotal);
            Map(x => x.PnLTotal);

            Map(x => x.CommisionTotal);
            Map(x => x.Shorts);
            Map(x => x.Longs);

            Map(x => x.IVWeightedAvg);
            Map(x => x.ImVolOnPutATM);
            Map(x => x.ImVolOnCallATM);
        }
    }
    public class SecurityDataComponent : ComponentMap<SecurityData>
    {
        public SecurityDataComponent()
        {
            Map(x => x.LastPrice);
            Map(x => x.PriorClosePrice).Column("OPENING_PRICE"); ;
            Map(x => x.Ask);
            Map(x => x.Bid);
            Map(x => x.Change);
            Map(x => x.HighestPrice);
            Map(x => x.LowestPrice);
            Map(x => x.LastUpdate);
        }
    }
    public class ManagedSecurityComponent : ComponentMap<ManagedSecurity>
    {
        public ManagedSecurityComponent()
        {
            Map(x => x.Symbol);
            Map(x => x.LastDayPnL);
            Map(x => x.MarginMaxAllowed);
        }
    }
    public class OrderStatusComponent : ComponentMap<OrderStatusData>
    {
        public OrderStatusComponent()
        {
            Map(x => x.OrderStatus);
            Map(x => x.Commission);
            Map(x => x.MaintMargin);
            Map(x => x.LastFillPrice);

        }
    }
    public class OptionDataComponent : ComponentMap<OptionData>
    {
        public OptionDataComponent()
        {
            Map(c => c.Delta);
            Map(c => c.Gamma);
            Map(c => c.Vega);
            Map(c => c.Theta);
            Map(c => c.ImpliedVolatility);
            Map(c => c.ModelPrice);
            Map(c => c.Ask);
            Map(c => c.Bid);
            Map(c => c.UnderlinePrice);

        }
    }
    public class OrderDataComponent : ComponentMap<OrderData>
    {
        public OrderDataComponent()
        {
            Map(x => x.LimitPrice);
            Map(x => x.OrderAction);
            Map(x => x.OrderId);
            Map(x => x.OrderType);
            Map(x => x.Quantity);
            Map(x => x.WhatIf);
            ReferencesAny(x => x.Contract)
                .EntityIdentifierColumn("ContractId")
                .EntityTypeColumn("ContractType")
                .IdentityType<String>()
                .AddMetaValue<OptionContract>("option")
                .AddMetaValue<SecurityContract>("stock");
        }
    }

    #endregion

    public class BaseContractMapper : ClassMap<ContractBase>
    {
        public BaseContractMapper()
        {
            UseUnionSubclassForInheritanceMapping();
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.Symbol);
            Map(x => x.Currency);
            Map(x => x.Exchange);
            //Map(x => x.Uid);
        }

    }

    public class OptionContractMapper : SubclassMap<OptionContract>
    {
        public OptionContractMapper()
        {
            Map(x => x.Strike);
            Map(x => x.Expiry);
            Map(x => x.Multiplier);
            Map(x => x.OptionType);
            Table("OptionsContracts");
        }
    }

    public class SecurityContractMapper : SubclassMap<SecurityContract>
    {
        public SecurityContractMapper()
        {
            Map(x => x.SecurityType);
            Table("SecurityContracts");
        }
    }


    public class BaseSecurityDataMapping : ClassMap<BaseSecurityData>
    {
        public BaseSecurityDataMapping()
        {
            UseUnionSubclassForInheritanceMapping();
            Id(x => x.Id).Column("Id").GeneratedBy.GuidComb();
            Map(c => c.Account).Default(AllConfigurations.AllConfigurationsObject.Application.MainAccount);
            Map(c => c.Ask);
            Map(c => c.AskSize);
            Map(c => c.PriorClosePrice);
            Map(c => c.Bid);
            Map(c => c.BidSize);
            Map(c => c.HighestPrice);
            Map(c => c.LastPrice);
            Map(c => c.LowestPrice);
            Map(c => c.Volume);
            Map(c => c.OpeningPrice);
            Map(c => c.LastUpdate);

        }
    }

    public class OptionDataMapping : SubclassMap<OptionData>
    {
        public OptionDataMapping()
        {
            Map(c => c.Delta);
            Map(c => c.Gamma);
            Map(c => c.Vega);
            Map(c => c.Theta);
            Map(c => c.ImpliedVolatility);
            Map(c => c.ModelPrice);
            //Map(c => c.Account).Default(AllConfigurations.AllConfigurationsObject.Application.MainAccount);
            References(x => x.OptionContract).Cascade.None();
            Table("OptionsData");
        }
    }

    public class SecurityDataMapping : SubclassMap<SecurityData>
    {
        public SecurityDataMapping()
        {
            References(x => x.SecurityContract);
            Table("SecurityData");
        }
    }

    public class PostionMapping : ClassMap<PositionData>
    {
        public PostionMapping()
        {
            UseUnionSubclassForInheritanceMapping();
            Id(x => x.Id).Column("Id").GeneratedBy.GuidComb();
            Map(c => c.AverageCost);
            Map(c => c.Position);
            Map(c => c.LastUpdate);
            //Map(c => c.Account).Default(AllConfigurations.AllConfigurationsObject.Application.MainAccount);
            // Map(c=>c\\\)
        }
    }

    public class OptionPositionDataMapping : SubclassMap<OptionsPositionData>
    {
        public OptionPositionDataMapping()
        {
            //References(x => x.OptionContract);C:\DevGit\robotrader\RoboTraderSuite\Infra\Configuration\
            //Table("OptionsPositions");

            References(x => x.OptionContract);
            Table("OptionsPositions");
        }
    }

 

    public class OrderStatus : ClassMap<OrderStatusData>
    {
        public OrderStatus()
        {
            Table("OrderStatus");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.OrderStatus);
            Map(x => x.Commission);
            Map(x => x.MaintMargin);
            Map(x => x.LastUpdateTime);
            Component(x => x.Order);
        }
    }

    class ManagedSecuritiesMapper : ClassMap<ManagedSecurity>
    {
        public ManagedSecuritiesMapper()
        {
            Table("ManagedSecurities");
            Id(x => x.Id);
            Map(c => c.Symbol);
            Map(c => c.Exchange);
            Map(c => c.Multiplier);
            Map(c => c.SecurityType);
            Map(c => c.Currency);
            Map(c => c.IsActive);
            Map(c => c.OptionChain);
            Map(c => c.MarginMaxAllowed);
            Map(c => c.LastDayPnL);

        }
    }
    class TransactionDataMapper : ClassMap<TransactionData>
    {
        public TransactionDataMapper()
        {
            Table("TransactionData");
            Id(x => x.Id);
            Map(c => c.Symbol);
            Map(c => c.OptionKey);
            Map(c => c.TransactionTime);
            Map(c => c.RequierdMargin);

            //Map(c => c.OptionData);
            //References(x => x.OptionData).Cascade.None();
            Component(x => x.OptionData);
            Component(x => x.OrderStatus);
            Component(x => x.Order);
        }
    }

    class UnlOptionsMapper : ClassMap<UnlOptions>
    {
        public UnlOptionsMapper()
        {
            Table("UnlOptions");
            Id(x => x.Id);
            Map(c => c.OptionKey);
            Map(c => c.LastUpdate);
            Map(c => c.Status).CustomType<int>();
            Map(c => c.Symbol);
            Map(c => c.Account).Default(AllConfigurations.AllConfigurationsObject.Application.MainAccount);
            References(x => x.OpenTransaction).Cascade.All().Column("OpenTransaction"); //.Cascade.All();
            References(x => x.CloseTransaction).Cascade.All().Column("CloseTransaction"); //.Cascade.All();
            References(x => x.OptionContract);

            Component(x => x.OptionData);
        }

    }

    class SavedParametersDataMapper : ClassMap<SavedParametersData>
    {
        public SavedParametersDataMapper()
        {
            Table("SavedParameters");
            Id(x => x.Id);
            Map(c => c.LastDBDillution);
            Map(c => c.LastNetLiquidition).Column("LastNetLiquidition");
            Map(c => c.LastUpdate);
        }
    }

    class UnlTradingDataMapper : ClassMap<UnlTradingData>
    {
        public UnlTradingDataMapper()
        {
            Table("UNL_TRADING_DATA");
            Id(x => x.Id);

            Map(c => c.Margin);
            Map(c => c.DailyPnL);
            //Map(c => c.LastUpdate);

            Component(x => x.ManagedSecurity); //==> Symbol; MaxAllowedMargin; LastDayPnL;
            Component(x => x.UnlSecurityData);
            Component(x => x.PositionsSummaryData);
        }
    }
}

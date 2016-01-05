using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TNS.API.ApiDataObjects;

namespace DAL
{


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
            Map(c => c.AskPrice);
            Map(c => c.AskSize);
            Map(c => c.BasePrice);
            Map(c => c.BidPrice);
            Map(c => c.BidSize);
            Map(c => c.HighestPrice);
            Map(c => c.LastPrice);
            Map(c => c.LowestPrice);
            Map(c => c.Volume);
            Map(c => c.OpeningPrice);

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
            References(x => x.OptionContract).Cascade.None() ;
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
        }
    }
    public class OptionPositionDataMapping : SubclassMap<OptionsPositionData>
    {
        public OptionPositionDataMapping()
        {
            References(x => x.OptionContract);
            Table("OptionsPositions");
        }
    }

    public class OrderDataMapper : ComponentMap<OrderData>
    {
        public OrderDataMapper()
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

    public class OrderStatus : ClassMap<OrderStatusData>
    {
        public OrderStatus()
        {
            Table("OrderStatus");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.OrderStatus);
            Map(x => x.Commission);
            Map(x => x.MaintMargin);
            Component(x => x.Order);
        }
    }
}

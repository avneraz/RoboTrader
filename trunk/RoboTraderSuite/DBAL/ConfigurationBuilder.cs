using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using TNS.Global;
using TNS.Global.Enum;

namespace TNS.DbDAL
{
    public class ConfigurationBuilder
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ConfigurationBuilder));

        /// <summary>
        /// Gets the main configurations object.
        /// </summary>
        /// <value>
        /// All configurations.
        /// </value>


        private static AllConfigurations _allConfigurations;

        /// <summary>
        /// Gets the main configurations object.
        /// </summary>
        /// <value>
        /// All configurations.
        /// </value>
        public static AllConfigurations AllConfigurations
        {
            get
            {
                if (_allConfigurations != null) return _allConfigurations;

                BuildAndInitializeConfiguration();
                return _allConfigurations;
            }
        }

        /// <summary>
        /// Make all action to retrieve configuration from database 
        /// and initialize the singleton configuration object.
        /// </summary>
        public static void BuildAndInitializeConfiguration()
        {
            _allConfigurations = new AllConfigurations();
            BuildConfiguration();
            //Update the reference on Global:
            AllConfigurations.AllConfigurationsObject = _allConfigurations;
        }

        private static void BuildConfiguration()
        {

            var allConfigType = typeof(AllConfigurations);
            var configPropertyInfos = allConfigType.GetProperties();
            foreach (var configPropertyInfo in configPropertyInfos)
            {
                var typeOfCat = configPropertyInfo.PropertyType;

                EConfigurationCategory conCategory;
                switch (typeOfCat.Name)
                {
                    case "ApplicationConfiguration":
                        conCategory = EConfigurationCategory.Application;
                        break;
                    case "TradingConfiguration":
                        conCategory = EConfigurationCategory.Trading;
                        break;
                    case "SessionConfiguration":
                        conCategory = EConfigurationCategory.Session;
                        break;
                    case "TradingAlarmConfiguration":
                        conCategory = EConfigurationCategory.TradingAlarm;
                        break;
                    default:
                        conCategory = EConfigurationCategory.Unknown;
                        break;

                }
                var propertyInfos = typeOfCat.GetProperties();//PropertyInfo[]
                if (!propertyInfos.Any())
                    continue;

                var catConfigurationList = GetConfigurationListForCategory(conCategory);
                if (catConfigurationList.Count == 0)
                    continue;

                GetConfiguration(propertyInfos, catConfigurationList, configPropertyInfo.GetValue(_allConfigurations));
            }
        }

        private static void GetConfiguration(IEnumerable<PropertyInfo> propertyInfos,
            List<Configuration> catConfigurationList, object configCatObject)
        {
            foreach (var propertyInfo in propertyInfos)
            {
                var configRecord = catConfigurationList.FirstOrDefault(con => con.Name.Trim().Equals(propertyInfo.Name));
                if (configRecord != null)
                {
                    object field = null;
                    switch (configRecord.Type.Trim())
                    {
                        case "int":
                            field = Convert.ToInt32(configRecord.Value);
                            break;
                        case "double":
                            field = Convert.ToDouble(configRecord.Value);
                            break;
                        default: //String
                            field = configRecord.Value;
                            break;
                    }
                    if (field != null) propertyInfo.SetValue(configCatObject, field);
                }
            }
        }

        public static List<Configuration> GetConfigurationList()
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    var configurationList = ctx.AppConfigurations.ToList();
                    return configurationList;
                }
            }
            catch (Exception ex)
            {

                Logger.Error("ConfigurationManager error: " + ex.Message, ex);
                throw;
            }
        }

        private static List<Configuration> GetConfigurationListForCategory(EConfigurationCategory eCategory)
        {
            try
            {
                var category = (int)eCategory;
                using (var ctx = new VegaEntities())
                {
                    var configurationList = ctx.AppConfigurations.Where(con => con.Category == category).ToList();
                    return configurationList;
                }
            }
            catch (Exception ex)
            {

                Logger.Error("ConfigurationManager error: " + ex.Message, ex);
                throw;
            }
        }

        public static void SaveConfiguration(List<Configuration> configurationList)
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    foreach (var configuration in configurationList)
                    {
                        if (configuration.ParameterId == 0)
                        {
                            ctx.AppConfigurations.Add(configuration);
                            ctx.SaveChanges();
                            continue;
                        }
                        ctx.AppConfigurations.Attach(configuration);
                        var entry = ctx.Entry(configuration);
                        entry.State = System.Data.Entity.EntityState.Modified;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                Logger.Error("ConfigurationManager error: " + ex.Message, ex);
                throw;
            }
        }

        public static bool DeleteConfigurationData(Configuration configuration)
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    ctx.AppConfigurations.Attach(configuration);
                    var entry = ctx.Entry(configuration);
                    entry.State = System.Data.Entity.EntityState.Deleted;
                    ctx.AppConfigurations.Remove(configuration);
                    var res = ctx.SaveChanges();
                    if (res <= 0)
                        throw new Exception(string.Format("Row '{0}' didn't deleted!!!!", configuration.Name));
                    return res > 0;
                }
            }
            catch (Exception ex)
            {

                Logger.Error("ConfigurationManager error: " + ex.Message, ex);
                throw;
            }
        }

    }
}

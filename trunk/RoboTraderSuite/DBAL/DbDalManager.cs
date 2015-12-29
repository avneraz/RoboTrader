using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using Infra;
using Infra.Enum;
using log4net.Repository.Hierarchy;

namespace TNS.DbDAL
{
    public static class DbDalManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DbDalManager));
        /// <summary>
        /// Gets all (not expired) active options chain for all underlines.
        /// </summary>
        /// <returns></returns>
        public static List<SessionsExpiration> GetAllActiveOptionChains()
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    var seList = ctx.SessionsExpirations.Where(se => se.ExpiryDate > DateTime.Today && se.IsActive);
                    return seList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("DbDalManager.GetAllActiveOptionChains():: " + ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Gets all (not expired) active options chain for specific underline.
        /// </summary>
        /// <returns></returns>
        public static List<SessionsExpiration> GetUNLActiveOptionChains(string symbol)
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    var seList = ctx.SessionsExpirations.Where(se =>se.Symbol== symbol && se.ExpiryDate > DateTime.Today && se.IsActive );
                    return seList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("DbDalManager.GetUNLActiveOptionChains():: " + ex.Message, ex);
                throw;
            }
        }
        /// <summary>
        /// Gets all (not expired) active options chain for specific underline.
        /// </summary>
        /// <returns></returns>
        public static List<DateTime> GetUNLActiveExpiryList(string symbol)
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    var seList = ctx.SessionsExpirations.Where(se => se.Symbol == symbol && se.ExpiryDate > DateTime.Today && se.IsActive).Select(se=>se.ExpiryDate);
                    return seList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("DbDalManager.GetUNLActiveExpiryList():: " + ex.Message, ex);
                throw;
            }
        }
        public static List<string> GetMainSecuritySymbolsList()
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    var contractList =
                        ctx.MainSecurities.Where(contract => contract.IsActive.Value).Select(c=>c.Symbol);
                    return contractList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("DbDalManager.GetActiveContractList():: " + ex.Message, ex);
                throw;
            }
        }
        public static List<MainSecurity> GetMainSecurityList()
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    var contractList =
                        ctx.MainSecurities.Where(contract => contract.IsActive.Value);
                    return contractList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("DbDalManager.GetActiveContractList():: " + ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Get all Active UNL that designate as an owner of Option Chain.
        /// </summary>
        /// <returns></returns>
        public static List<MainSecurity> GetActiveUNLList()
        {
            try
            {
                using (var ctx = new VegaEntities())
                {
                    var contractList =
                        ctx.MainSecurities.Where(contract => contract.IsActive.Value && contract.OptionsChain.Value);
                    return contractList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("DbDalManager.GetActiveContractList():: " + ex.Message, ex);
                throw;
            }
        }
    }
}

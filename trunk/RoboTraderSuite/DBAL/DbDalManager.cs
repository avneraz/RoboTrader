using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using TNS.Global;
using TNS.Global.Enum;
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
        public static List<MainSecurity> GetActiveContractList()
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

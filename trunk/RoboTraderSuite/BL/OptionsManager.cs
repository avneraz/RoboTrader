namespace TNS.BL
{
    public class OptionsManager
    {
        /// <summary>
        /// Loads the options chain of all active session of the active underlineds.
        /// It send Request Contract details to load the option chain of the specified UNL.
        /// </summary>
        //public void LoadOptionsChain()
        //{
        //    var activeSecChainList = DbDalManager.GetAllActiveOptionChains();
        //    var contractChainList = activeSecChainList.Join(ActiveContractList, chain => chain.Symbol,
        //        con => con.Symbol, (x, y) => new { SessionsExpiration = x, SecurityContracts = y }).ToList();

         
        //}
        #region OptionData and contracts for the entire Securities



        //private OptionContract GetNewOptionChainContract(SessionsExpiration sessionsExpiration, SecurityContract securityContract)
        //{

        //    var optionContract = new OptionContract(SecurityContract.Symbol, );
        //     //new OptionContract
        //     //{
        //     //    Symbol = securityContract.Symbol,
        //     //    //SecType = "OPT",//"OPT",
        //     //    Exchange = securityContract.Exchange,//"SMART",
        //     //    Currency = securityContract.Currency, //"USD",
        //     //    Expiry = GetExpiryDateString(sessionsExpiration.SessionKey),//expiryDateStr,
        //     //    Multiplier = securityContract.Multiplier//"100"
        //     //};
        //    return optionContract;
        //}




        //private List<SecurityContract> _activeContractList;
        //public List<SecurityContract> ActiveContractList
        //{
        //    get
        //    {
        //        if (_activeContractList != null)
        //            return _activeContractList; 

        //        _activeContractList = DbDalManager.GetActiveContractList();
        //        var listCount = _activeContractList.Count;
        //        //for (int i = 0; i < listCount; i++)
        //        //{
        //        //    _activeContractList[i].SecurityRequestDataId = MAIN_SECURITIES_BASE + i + 1;
        //        //}

        //        return _activeContractList;
        //    }
        //}

        #endregion

    }
}

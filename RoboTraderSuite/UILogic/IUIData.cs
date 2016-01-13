namespace UILogic
{
    public interface IUIData
    {
        UIDataManager UIDataManager { get; set; }
        void SetUIDataManager(UIDataManager uiDataManager);
    }
}

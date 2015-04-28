namespace PrismDataTemplateExample.Models
{
    public class DataItem : DataBase
    {
        private string _name;

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChangedAuto();
            }
        }

        #endregion
    }
}
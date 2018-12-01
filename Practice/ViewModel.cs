using System.ComponentModel;

namespace Practice
{
    public class ViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        // Model objects
        public int Age { get; set; }
        public string Name  { get; set; }

        private bool canValidate;
        public event PropertyChangedEventHandler PropertyChanged;

        // Validation switch
        public bool CanValidate
        {
            get { return canValidate; }
            set
            {
                canValidate = value;
                OnPropertyChanged("CanValidate");
                OnPropertyChanged("Name");
                OnPropertyChanged("Age");
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string result = null;

                if (CanValidate)
                {
                    // Validate Name
                    if (name == "Name")
                    {
                        if (this.Name == "Ethan" || this.Name == "ethan")
                        {
                            result = "That's a bad name, please choose a different name!";
                        }
                    }

                    // Validate Age
                    if (name == "Age")
                    {
                        if (this.Age < 0 || this.Age > 80)
                        {
                            result = "Age must not be less than 0 or greater than 80.";
                        }
                    }
                }

                return result;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

// Developer Express Code Central Example:
// How to display a line when the DXGrid doesn't include any record
// 
// This sample shows how to display a line within the grid's view if it does not
// contain any rows.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3060

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SLGridExample {
    public class PersonsViewModel {
        ObservableCollection<Person> persons;
        
        public PersonsViewModel() {
            List<string> Names = new List<string> { "Alex", "Alice", "Tony", "Den", "Andrew", "John", "Donald", "Brian", "Effy", "Lisa", "Matthew" };
            persons = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++) {
                persons.Add(new Person(Names[i % 10], "Last name " + i, 21 + i, i % 2 == 0, 170 + i, 75 + i));
            }
            persons[5].Age = 22;
            persons[8].Age = 50;
        }

        public void RemovePerson(object item) {
            if( !(item is Person) ) return;
            persons.Remove((Person)item);
        }

        public ObservableCollection<Person> Persons {
            get {
                return persons;
            }
        }
    }

    public class Person : INotifyPropertyChanged, IDataErrorInfo {
        const string lastNamePropertyName = "LastName";
        const string firstNamePropertyName = "FirstName";
        const string agePropertyName = "Age";
        const string heightPropertyName = "IsMarried";
        const string isMarriedPropertyName = "Height";
        const string weightPtropertyName = "Weight";

        string firstName;
        string lastName;
        int age;
        bool isMarried;
        int height;
        int weight;
        PersonPropertiesValidator Validator = new PersonPropertiesValidator();

        public Person(string firstName, string lastName, int age, bool isMarried, int height, int weight) {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsMarried = isMarried;
            Weight = weight;
            Height = height;
        }

        public string FirstName {
            get {
                return firstName;
            }
            set {
                Validator.IsNameValid(value, firstNamePropertyName);
                firstName = value;
                RaisePropertyChanged(firstNamePropertyName);
            }
        }

        public string LastName {
            get {
                return lastName;
            }
            set {
                Validator.IsNameValid(value, lastNamePropertyName);
                lastName = value;
                RaisePropertyChanged(lastNamePropertyName);
            }
        }

        public int Age {
            get {
                return age;
            }
            set {
                Validator.IsAgeValid(value, agePropertyName);
                age = value;
                RaisePropertyChanged(agePropertyName);
            }
        }

        public bool IsMarried {
            get {
                return isMarried;
            }
            set {
                isMarried = value;
                RaisePropertyChanged(isMarriedPropertyName);
            }
        }

        public int Height {
            get {
                return height;
            }
            set {
                height = value;
                RaisePropertyChanged(heightPropertyName);
            }
        }

        public int Weight {
            get {
                return weight;
            }
            set {
                weight = value;
                RaisePropertyChanged(weightPtropertyName);
            }
        }

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDataErrorInfo members
        public string Error {
            get {
                return Validator.DataError;
            }
        }

        public string this[string columnName] {
            get {
                if (Validator.DataErrors.ContainsKey(columnName))
                    return Validator.DataErrors[columnName];
                else
                    return null;
            }
        }
        #endregion
    }

    public class PersonPropertiesValidator {
        string dataError = "";
        Dictionary<string, string> dataErrors = new Dictionary<string, string>();

        public bool IsNameValid(string value, string propertyName) {
            if (string.IsNullOrEmpty(value)) {
                dataErrors[propertyName] = "Full name is required.";
                return false;
            } else {
                ClearPropertyErrors(propertyName);
                return true;
            }
        }

        public bool IsAgeValid(int value, string propertyName) {
            if (value <= 0) {
                dataErrors[propertyName] = "Age validation failed.";
                return false;
            } else {
                ClearPropertyErrors(propertyName);
                return true;
            }
        }

        public string DataError {
            get {
                return dataError;
            }
        }

        public Dictionary<string, string> DataErrors {
            get {
                return dataErrors;
            }
        }

        void ClearPropertyErrors(string propertyName) {
            if (dataErrors.ContainsKey(propertyName))
                dataErrors.Remove(propertyName);
        }
    }
}

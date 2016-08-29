using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ListViewSort.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewSort.ViewModels
{
    public class ListPageViewModel : INotifyPropertyChanged
    {
        //List for original list.
        private ObservableCollection<CarModel> OrgCarList = new ObservableCollection<CarModel>();

        //Constructor
        public ListPageViewModel()
        {
            PopulateList();
            CarObserveList = OrgCarList;
            Car = new CarModel();
        }

        //Field 
        private CarModel _car;
        public CarModel Car
        {
            get
            {
                return _car;
            }
            set
            {
                _car = value;
                OnPropertyChanged();
            }
        }

        // Message
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        //Property and field for an obserable collection / List for personmodel objects.
        private ObservableCollection<CarModel> _carObserveList = new ObservableCollection<CarModel>();
        public ObservableCollection<CarModel> CarObserveList
        {
            get
            { return _carObserveList; }
            set
            {
                _carObserveList = value;
                OnPropertyChanged();
            }
        }

        //Searches the original car list for cars, adds to ienumerable and converts to observable and returns it.
        private ObservableCollection<CarModel> SearchList(string searchWord)
        {            
            IEnumerable<CarModel> matches = OrgCarList.Where(Car => Car.Make.Contains(searchWord));

            var tempList = new ObservableCollection<CarModel>(matches);
            return tempList;
        }

        //Command for when user presses item in persons listview. 
        private Command _onTextChangedCommand;
        public ICommand OnTextChangedCommand
        {
            get
            {
                if (_onTextChangedCommand == null)
                {
                    _onTextChangedCommand = new Command(HandleOnTextChanged);
                }

                return _onTextChangedCommand;
            }
        }

        //This method executes when a user has pressed something in the persons listview. 
        private void HandleOnTextChanged(object parameter)
        {
            string searchWord = parameter as string;
            if(searchWord == string.Empty) 
            {
                CarObserveList = OrgCarList; //Empty fill list with orginal list.
            }
            else
            {
                CarObserveList = SearchList(searchWord);
            }
        }

        //Mock data to populate the list with values.
        private void PopulateList()
        {
            OrgCarList.Add(new CarModel
            {
                Make = "Volvo",
                TypeOfCar = "Family car",
                Year = 1999
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Saab",
                TypeOfCar = "Family car",
                Year = 2008
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Ferrari",
                TypeOfCar = "Sports car",
                Year = 2009
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Mercedes",
                TypeOfCar = "Saloon car",
                Year = 2014
            });
            OrgCarList.Add(new CarModel
            {
                Make = "BMW",
                TypeOfCar = "Family car",
                Year = 2015
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Volvo",
                TypeOfCar = "Family car",
                Year = 2015
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Saab",
                TypeOfCar = "Family car",
                Year = 2010
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Bently",
                TypeOfCar = "Luxury car",
                Year = 2013
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Nissan",
                TypeOfCar = "Family car",
                Year = 1999
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Mitsubishi",
                TypeOfCar = "SUV",
                Year = 1999
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Volvo",
                TypeOfCar = "SUV",
                Year = 1999
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Saab",
                TypeOfCar = "SUV",
                Year = 1999
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Nissan",
                TypeOfCar = "SUV",
                Year = 1999
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Nissan",
                TypeOfCar = "Spors car",
                Year = 1999
            });
            OrgCarList.Add(new CarModel
            {
                Make = "Bently",
                TypeOfCar = "Very Luxury car",
                Year = 2013
            });
        }

        //Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

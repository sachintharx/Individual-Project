using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LMS_SYT.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LMS_SYT
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");
                
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/01.png", UriKind.Relative));
            users.Add(new User(23, "John", "Johnson", "12/05/2000",image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/02.png", UriKind.Relative));
            users.Add(new User(23, "Emma", "Lee", "07/11/2000",image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/03.png", UriKind.Relative));
            users.Add(new User(24, "Michael", "Clark", "27/08/1999",image3));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/04.png", UriKind.Relative));
            users.Add(new User(23, "William", "Brown", "01/07/2000", image4));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/05.png", UriKind.Relative));
            users.Add(new User(25, "Olivia", "Taylor", "17/03/1998", image5));

        }
    }
}

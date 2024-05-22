using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RaiseHope
{
    public partial class MainWindow : Window
    {
        private UserProfile currentUser;
        private string currentRole;

        public MainWindow()
        {
            InitializeComponent();
            GenderComboBox.Items.Add("Male");
            GenderComboBox.Items.Add("Female");
            GenderComboBox.Items.Add("Custom");
        }

        private void AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            currentRole = "Admin";
            ShowLoginSignupScreen();
        }

        private void DonorLogin_Click(object sender, RoutedEventArgs e)
        {
            currentRole = "Donor";
            ShowLoginSignupScreen();
        }

        private void ReceptorLogin_Click(object sender, RoutedEventArgs e)
        {
            currentRole = "Receptor";
            ShowLoginSignupScreen();
        }

        private void ShowLoginSignupScreen()
        {
            RoleSelectionGrid.Visibility = Visibility.Collapsed;
            LoginSignupGrid.Visibility = Visibility.Visible;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Implement actual login logic here
            // For now, let's assume login is always successful and show the profile screen

            currentUser = new UserProfile
            {
                FirstName = "Usama",
                LastName = "Ali",
                Email = "usamaalikhan@example.com",
                Username = username,
                Gender = "Male",
                DateOfBirth = "27/08/2002"
            };

            if (currentRole == "Donor")
            {
                currentUser.DonationHistory = new List<string>
                {
                    "Donated $100 on 01/01/2022",
                    "Donated $50 on 01/02/2022"
                };
            }
            else if (currentRole == "Receptor")
            {
                currentUser.ReceivedFundsHistory = new List<string>
                {
                    "Received $200 on 01/01/2022",
                    "Received $100 on 01/02/2022"
                };
            }

            ShowUserProfileScreen();
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string username = SignupUsernameTextBox.Text;
            string password = SignupPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string gender = GenderComboBox.SelectedItem?.ToString();
            string dateOfBirth = DatePicker.SelectedDate?.ToString();

            // Implement actual signup logic here
            // For now, let's assume signup is always successful and show the profile screen

            currentUser = new UserProfile
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Username = username,
                Gender = gender,
                DateOfBirth = dateOfBirth
            };

            ShowUserProfileScreen();
        }

        private void ShowUserProfileScreen()
        {
            LoginSignupGrid.Visibility = Visibility.Collapsed;
            UserProfileGrid.Visibility = Visibility.Visible;

            ProfileFirstName.Text = currentUser.FirstName;
            ProfileLastName.Text = currentUser.LastName;
            ProfileEmail.Text = currentUser.Email;
            ProfileGender.Text = currentUser.Gender;
            ProfileDOB.Text = currentUser.DateOfBirth;

            if (currentRole == "Donor")
            {
                DonationHistoryHeader.Visibility = Visibility.Visible;
                DonationHistoryList.Visibility = Visibility.Visible;
                ReceivedFundsHistoryHeader.Visibility = Visibility.Collapsed;
                ReceivedFundsHistoryList.Visibility = Visibility.Collapsed;

                DonationHistoryList.ItemsSource = currentUser.DonationHistory;
            }
            else if (currentRole == "Receptor")
            {
                DonationHistoryHeader.Visibility = Visibility.Collapsed;
                DonationHistoryList.Visibility = Visibility.Collapsed;
                ReceivedFundsHistoryHeader.Visibility = Visibility.Visible;
                ReceivedFundsHistoryList.Visibility = Visibility.Visible;

                ReceivedFundsHistoryList.ItemsSource = currentUser.ReceivedFundsHistory;
            }
            else
            {
                DonationHistoryHeader.Visibility = Visibility.Collapsed;
                DonationHistoryList.Visibility = Visibility.Collapsed;
                ReceivedFundsHistoryHeader.Visibility = Visibility.Collapsed;
                ReceivedFundsHistoryList.Visibility = Visibility.Collapsed;
            }
        }
    }
}

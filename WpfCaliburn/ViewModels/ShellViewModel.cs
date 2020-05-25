using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfCaliburn.Models;
using System.Threading;

namespace WpfCaliburn.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        #region privates
        private string _firstName = "Tim";
		private string _lastName;
		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
		private PersonModel _selectedPerson;
		#endregion

		public ShellViewModel()
		{
			People.Add(new PersonModel { FirstName = "Jan", LastName = "Chvila" });
			People.Add(new PersonModel { FirstName = "Martin", LastName = "Novak" });
			People.Add(new PersonModel { FirstName = "Eva", LastName = "Farna" });
		}
		public string FirstName
		{
			get 
			{ 
				return _firstName; 
			}
			set 
			{ 
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set 
			{ 
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string FullName {
			get { return $"{FirstName} {LastName}"; }  
		}


		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}

		public PersonModel SelectedPerson
		{
			get { return _selectedPerson; }
			set 
			{ 
				_selectedPerson = value;
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}

		public bool CanClearText(string firstName, string lastName)
		{
			if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
				return false;
			else
				return true;
			//return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
		}
		public void ClearText(string firstName, string lastName)
		{
			FirstName = "";
			LastName = "";
		}

		public async Task  LoadPageOne()
		{
			//ActivateItem(new SecondChildViewModel());
			await ActivateItemAsync(new FirstChildViewModel(), CancellationToken.None);
			
		}
		public async Task LoadPageTwo()
		{
			//ActivateItem(new SecondChildViewModel());
			await ActivateItemAsync(new SecondChildViewModel(), CancellationToken.None);

		}

	}
}

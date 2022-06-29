using AutoService.Models;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.TransferObjects;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoService.ViewModel
{
    public class MainReviewsViewModel : BaseViewModel
    {
        private readonly MainWindowViewModel _vm;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private ReviewObject _addReview;

        public MainReviewsViewModel(MainWindowViewModel vm)
        {
            this._vm = vm;

            Reviews = new ObservableCollection<ReviewObject>(
                _vm.UnitOfWork.ReviewRepository
                .GetAll()
                .Select(s => new ReviewObject(s.Id, s.Title, s.Description, s.CreatedAt, _vm.CurrentCustomer.Id == s.CustomerId, s.Customer)));

            AddReview = new ReviewObject
            {
                Customer = _vm.UnitOfWork.CustomerRepository.GetEntityByConditionOrDefault(c => c.Id == _vm.CurrentCustomer.Id)
            };
        }
        public ObservableCollection<ReviewObject> Reviews { get; set; }
        public ReviewObject AddReview
        {
            get { return _addReview; }
            set
            {
                _addReview = value;
                OnPropertyChanged(nameof(AddReview));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand((o) =>
                {
                    if(!string.IsNullOrEmpty(AddReview.Title) && !string.IsNullOrEmpty(AddReview.Description))
                    {
                        Review newReview = new Review
                        {
                            Id = AddReview.Id,
                            Title = AddReview.Title,
                            Description = AddReview.Description,
                            CreatedAt = AddReview.CreatedAt,
                            CustomerId = _vm.CurrentCustomer.Id
                        };

                        _vm.UnitOfWork.ReviewRepository.Add(newReview);

                        _vm.UnitOfWork.SaveChanges();

                        Reviews.Add(AddReview);

                        AddReview = new ReviewObject
                        {
                            Customer = _vm.UnitOfWork.CustomerRepository.GetEntityByConditionOrDefault(c => c.Id == _vm.CurrentCustomer.Id)
                        };
                    }

                }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand((o) =>
                {
                    var delReview = o as ReviewObject;

                    if(delReview != null)
                    {
                        var rew = _vm.UnitOfWork.ReviewRepository.GetEntityByConditionOrDefault(r => r.Id == delReview.Id);

                        _vm.UnitOfWork.ReviewRepository.Delete(rew);

                        _vm.UnitOfWork.SaveChanges();

                        Reviews.Remove(delReview);
                    }

                }));
            }
        }
    }
}
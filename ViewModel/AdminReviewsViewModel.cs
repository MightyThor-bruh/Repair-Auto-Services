using AutoService.Models;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using System.Collections.ObjectModel;

namespace AutoService.ViewModel
{
    public class AdminReviewsViewModel : BaseViewModel
    {
        private readonly MainAdminViewModel _vm;
        private RelayCommand _deleteCommand;

        public AdminReviewsViewModel(MainAdminViewModel vm)
        {
            this._vm = vm;
            Reviews = new ObservableCollection<Review>(
                _vm.UnitOfWork.ReviewRepository
                .GetAll());
        }
        public ObservableCollection<Review> Reviews { get; set; }
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand((o) =>
                {
                    var delReview = o as Review;

                    if (delReview != null)
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
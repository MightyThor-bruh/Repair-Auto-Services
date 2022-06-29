using AutoService.ViewModel.Validation;
using System;

namespace AutoService.ViewModel.TransferObjects
{
    public class EmpObject : NotifyDataErrorInfo<EmpObject>
    {
        private string _name;
        private string _surname;
        private string _exp;

        static EmpObject()
        {
            Rules.Add(new DelegateRule<EmpObject>(
                nameof(Name),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Name)));
            Rules.Add(new DelegateRule<EmpObject>(
                nameof(Surname),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Surname)));
            Rules.Add(new DelegateRule<EmpObject>(
                nameof(Exp),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Exp)));
            Rules.Add(new DelegateRule<EmpObject>(
                nameof(Exp),
                "Число",
                x => _ = int.TryParse(x.Exp, out int val)));
        }
        public EmpObject() { }
        public EmpObject(
            Guid id,
            string name,
            string surname,
            int exp)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Exp = exp.ToString();
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }
        public string Exp
        {
            get { return _exp; }
            set
            {
                if (int.TryParse(value, out int val))
                {
                    SetProperty(ref _exp, value);
                }
                else
                {
                    SetProperty(ref _exp, "");
                }
            }
        }
    }
}

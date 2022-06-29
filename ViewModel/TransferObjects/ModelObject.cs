using AutoService.Models;
using AutoService.Models.Enums;
using AutoService.ViewModel.Validation;

namespace AutoService.ViewModel.TransferObjects
{
    public class ModelObject : NotifyDataErrorInfo<ModelObject>
    {
        private string _name;
        private string _power;
        private string _accelerationSec;
        private int _producerId;
        private ModelTypes _modelType;
        private string _producerName;
        private string _modelTypeName;
        static ModelObject()
        {
            Rules.Add(new DelegateRule<ModelObject>(
                nameof(Name),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Name)));
            Rules.Add(new DelegateRule<ModelObject>(
                nameof(Power),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Power)));
            Rules.Add(new DelegateRule<ModelObject>(
                nameof(Power),
                "Число",
                x => _ = double.TryParse(x.Power, out double val)));
            Rules.Add(new DelegateRule<ModelObject>(
                nameof(AccelerationSec),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.AccelerationSec)));
            Rules.Add(new DelegateRule<ModelObject>(
                nameof(AccelerationSec),
                "Число",
                x => _ = double.TryParse(x.AccelerationSec, out double val)));
        }
        public ModelObject() { }
        public ModelObject(
            int id,
            string name,
            double power,
            double accelerationSec,
            Producer producer,
            ModelType modelType)
        {
            this.Id = id;
            this.Name = name;
            this.Power = power.ToString();
            this.AccelerationSec = accelerationSec.ToString();
            this.ProducerId = producer.Id;
            this.ProducerName = producer.Name;
            this.ModelType = modelType.Id;
            this.ModelTypeName = modelType.Name;
        }
        public int Id { get; set; }
        public string ProducerName
        {
            get => _producerName;
            set => SetProperty(ref _producerName, value);
        }
        public string ModelTypeName
        {
            get => _modelTypeName;
            set => SetProperty(ref _modelTypeName, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public int ProducerId
        {
            get => _producerId;
            set => SetProperty(ref _producerId, value);
        }
        public ModelTypes ModelType
        {
            get => _modelType;
            set => SetProperty(ref _modelType, value);
        }
        public string Power
        {
            get { return _power; }
            set
            {
                var tmp = value.Replace(',', '.');
                SetProperty(ref _power, tmp);
            }
        }
        public string AccelerationSec
        {
            get { return _accelerationSec; }
            set
            {
                var tmp = value.Replace(',', '.');
                SetProperty(ref _accelerationSec, tmp);
            }
        }
    }
}

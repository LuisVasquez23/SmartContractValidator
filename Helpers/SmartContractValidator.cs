namespace SmartContractValidator.Helpers
{
    public class SmartContractValidator
    {

        private readonly List<Func<bool>> _validationPoints;

        public SmartContractValidator()
        {
            _validationPoints = new List<Func<bool>>();
        }

        #region ADD A VALIDATION POINT TO THE CONTRACT
        public void AddValidationPoint(Func<bool> validationPoint)
        {
            _validationPoints.Add(validationPoint);
        }
        #endregion

        #region VALIDATE CONTRACT BY CHECKING ALL VALIDATION POINTS
        public bool Validate()
        {
            return _validationPoints.All( validationPoint => validationPoint());
        }
        #endregion
    }
}

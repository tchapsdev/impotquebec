using Microsoft.AspNetCore.Identity;

namespace impotquebec.Web.Models
{
    public class IncomeDeduction
    {
        public int IncomeDeductionId { get; set; }
        public double DeductionForWorkers  { get; set; }
        public double RegisteredPensionPlanDeduction { get; set; }
        public double EmploymentExpensesAndDeductions  { get; set; }
        public double RrspPrppVrspDeduction { get; set; }
        public double SupportPaymentsMade { get; set; }
        public double MovingExpenses { get; set; }
        public double CarryingChargesAndInterestExpenses { get; set; }
        public double BusinessInvestmentLoss { get; set; }
        public double DeductionForResidentsOfDesignatedRemoteAreas { get; set; }
        public double DeductionForExplorationAndDevelopmentExpenses { get; set; }
        public double DeductionForRetirementIncomeTransferredToYourSpouse { get; set; }
        public double DeductionForARepaymentOfAmountsOverpaidToYou { get; set; }
        public double DeductionForQppAndCppContributionsAndQpipPremiums  { get; set; }
        public double OtherDeductions { get; set; }
        // Total deductions L298
        private double _totalDeductions => DeductionForWorkers + RegisteredPensionPlanDeduction
            + EmploymentExpensesAndDeductions + RrspPrppVrspDeduction + SupportPaymentsMade
            + MovingExpenses + CarryingChargesAndInterestExpenses + BusinessInvestmentLoss + DeductionForResidentsOfDesignatedRemoteAreas
            + DeductionForExplorationAndDevelopmentExpenses + DeductionForRetirementIncomeTransferredToYourSpouse
            + DeductionForARepaymentOfAmountsOverpaidToYou + DeductionForQppAndCppContributionsAndQpipPremiums
            + OtherDeductions;

        public double TotalDeductions { get { return _totalDeductions; } }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int IncomeId { get; set; }
        public Income Income { get; set; }
    }
}

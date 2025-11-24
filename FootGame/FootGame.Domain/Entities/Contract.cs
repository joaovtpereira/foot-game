namespace FootGame.Domain.Entities;
using FootGame.Domain.Enums;

public class Contract
{
    public Guid Id { get; private set; }
    public Guid PersonId { get; private set; }
    public Guid TeamId { get; private set; }
    public ContractType ContractType { get; private set; }
    public ContractStatus? StatusContract { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal SalaryPerMonth { get; private set; }
    public Guid? LoanContractId { get; private set; }

    public Contract(Guid personId, Guid teamId, ContractType contractType, ContractStatus statusContract, DateTime startContractDate, DateTime endContractDate, decimal salaryPerMonth, Guid? loanContractId = null)
    {
        Boolean haveAtLeastOneMonth = startContractDate.AddMonths(1) <= endContractDate;
        if(!haveAtLeastOneMonth)
        {
            throw new ArgumentException("Contract must be at least 1 month long.");
        }

        if(salaryPerMonth <= 0)
        {
            throw new ArgumentException("Salary per month cannot be less than or equal to 0.");
        }

        Id = Guid.NewGuid();
        PersonId = personId;
        TeamId = teamId;
        ContractType = contractType;
        StatusContract = statusContract;
        StartDate = startContractDate;
        EndDate = endContractDate;
        SalaryPerMonth = salaryPerMonth;
        LoanContractId = loanContractId;
    }

    public LoanContract LoanTo(Guid loanTeamId, DateTime startContractDate, DateTime endContractDate, decimal salaryPerMonth)
    {
        if(ContractType != ContractType.UnderContract)
        {
            throw new ArgumentException("Only under contract contracts can be loaned.");
        }

        ContractType = ContractType.Loan;
        LoanContract loanContract = new LoanContract(Id, loanTeamId, startContractDate, endContractDate, salaryPerMonth);

        LoanContractId = loanContract.Id;
        return loanContract;
    }

    public Contract VerifyContractStatus(DateTime currentDateCalendar)
    {
        Boolean isExpired = currentDateCalendar > EndDate;
        if(isExpired)
        {
            StatusContract = null;
            ContractType = ContractType.Expired;
            LoanContractId = null;

            return this;
        }

        Boolean lastSixMonths = currentDateCalendar.AddMonths(7) > EndDate;

        if(lastSixMonths)
        {
            StatusContract = ContractStatus.NearExpiration;
        }

        return this;
    }
}
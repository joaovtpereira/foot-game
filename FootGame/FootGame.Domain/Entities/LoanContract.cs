namespace FootGame.Domain.Entities;

public class LoanContract
{
    public Guid Id { get; private set; }
    public Guid OriginalContractId { get; private set; }
    public Guid LoanTeamId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal SalaryPerMonth { get; private set; }

    public LoanContract(Guid originalContractId, Guid loanTeamId, DateTime startContractDate, DateTime endContractDate, decimal salaryPerMonth)
    {
        Boolean haveAtLeastSixMonths = startContractDate.AddMonths(6) <= endContractDate;
        if(!haveAtLeastSixMonths)
        {
            throw new ArgumentException("Contract must be at least 6 months long.");
        }

        if(salaryPerMonth <= 0)
        {
            throw new ArgumentException("Salary per month cannot be less than or equal to 0.");
        }

        Id = Guid.NewGuid();
        OriginalContractId = originalContractId;
        LoanTeamId = loanTeamId;
        StartDate = startContractDate;
        EndDate = endContractDate;
        SalaryPerMonth = salaryPerMonth;
    }
}
namespace LastWork.Models.InstructionSteps
{
    public class DataStepRepository: IStepRepository
    {
        private readonly DataContext context;

         public DataStepRepository(DataContext context) 
         {
             this.context = context;
         }
    }
}
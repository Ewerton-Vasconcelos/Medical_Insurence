using Medical_Insurence.Models;

namespace Medical_Insurence.Repositorys
{
    public class LogicQuestionsRepository
    {
        public LogicQuestionsRepository() { }

        public int Calc(List<CalculedScore> scores) {
            
            int pontuation = 0;

            foreach (var score in scores)
            {
                
                if(score.Type == "consulta")
                {
                    pontuation += 10;

                }else if(score.Type == "laboratorial")
                {
                    pontuation += 15;
                }
                else
                {
                    pontuation += 20;
                }
            }

            return pontuation;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Models;


namespace SurveyApp.Services
{
    public class SurveyService
    {
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task Add(Survey survey)
        {
            if (survey != null)
            {
                await _context.Surveys.AddAsync(survey);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Survey>> GetAll()
        {
            return await _context.Surveys
                .Include(s => s.Questions)
                .ToListAsync();
        }


        public async Task<List<Survey>> GetAllRecords()
        {
            var existRecord = _context.SurveyResponses
                    .Select(s => s.SurveyId)
                    .ToList();


            var surveys = await _context.Surveys
                    .Include(s => s.Questions)
                    .Where(s => existRecord.Contains(s.Id))
                    .ToListAsync();

            return surveys;
        }

        public async Task<Survey> GetById(int id)
        {
            var existRecord = await _context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).FirstOrDefaultAsync(s => s.Id == id);
            return existRecord;
        }

        public async Task<bool> SubmitSurveyResponse(SurveyResponse surveyResponse)
        {
            if (surveyResponse != null)
            {
                _context.SurveyResponses.Add(surveyResponse);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }


        // Oluşturulan bir Anketi sil. Yapılan bir anket değildir!
        public async Task Delete(Survey survey)
        {
            if (survey.Id > 0)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<List<SurveyResponse>> GetSurveyResponses()
        {
            return await _context.SurveyResponses
                                 .Include(sr => sr.SurveyAnswers)
                                 .ThenInclude(sa => sa.Question)
                                 .ThenInclude(q => q.Answers)
                                 .ToListAsync();
        }

        // Yapılmış bir anketi Id sine göre getir.
        public async Task<List<SurveyResponse>> GetSurveyByMainId(int surveyId)
        {

            return await _context.SurveyResponses.Include(sr => sr.SurveyAnswers).Where(s => s.SurveyId == surveyId).ToListAsync();
        }

        // Anket Cevaplarını getir.
        public async Task<List<string>> GetSurveyAnswers(int surveyId)
        {
            var data = await _context.Questions
                .Where(q => q.Surveys.Any(s => s.Id == surveyId))
                .OrderBy(q => q.Id)
                .Select(q => new
                {
                    AnswerNames = q.Answers.Select(a => a.Title).ToList(),

                })
                .FirstOrDefaultAsync();

            return data.AnswerNames;
        }

        // Anket Cevap Puanlarını getir
        public async Task<List<string>> GetSurveyPoints(int surveyId)
        {
            var data = await _context.Questions
                .Where(q => q.Surveys.Any(s => s.Id == surveyId))
                .OrderBy(q => q.Id)
                .Select(q => new
                {
                    AnswerPoint = q.Answers.Select(a => a.Point).ToList(),

                })
                .FirstOrDefaultAsync();

            return data.AnswerPoint;
        }


        // Anket sorularını getir.
        public async Task<List<Question>> GetSurveyQuestions(int surveyId)
        {
            return _context.Questions.Include(q => q.Surveys.Where(q => q.Id == surveyId)).ToList();
        }

        public async Task Delete2(SurveyResponse surveyResponse)
        {

            _context.SurveyResponses.Remove(surveyResponse);
            await _context.SaveChangesAsync();

        }
    }
}

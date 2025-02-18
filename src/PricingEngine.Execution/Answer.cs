namespace PricingEngine.Execution;

public class Answer
{
    public Answer(int questionId, object value)
    {
        QuestionId = questionId;
        Value = value;
    }

    public int QuestionId { get; private set; }
    public object Value { get; private set; }
}
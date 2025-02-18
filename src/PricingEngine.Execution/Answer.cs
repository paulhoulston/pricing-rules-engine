namespace PricingEngine.Execution;

using System;

public class Answer
{
    public Answer(Guid questionId, object value)
    {
        QuestionId = questionId;
        Value = value;
    }

    public Guid QuestionId { get; private set; }
    public object Value { get; private set; }
}
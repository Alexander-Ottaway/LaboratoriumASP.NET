
using WebApp.Controllers;

namespace WebApp.Models;

public class Calculator
{
    public Operators? Operator { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public String Op
    {
        get
        {
            switch (Operator)
            {
                case Operators.Add:
                    return "+";
                case Operators.Sub:
                    return "-";
                case Operators.Mul:
                    return "*";
                case Operators.Div:
                    return "/";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && X != null && Y != null;
    }

    public double Calculate() {
        switch (Operator)
        {
            case Operators.Add:
                return (double) (X + Y);
            case Operators.Sub:
                return (double)(X - Y);
            case Operators.Mul:
                return (double)(X * Y);
            case Operators.Div:
                return (double)(X / Y);
            default: return double.NaN;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra
{
    public static class PostUtil
    {
        public static string GetTimeAgoFromDateTime(DateTime date)
        {
            TimeSpan difference = DateTime.Now.Subtract(date);

            if (difference.TotalDays < 365)
            {
                if (difference.TotalDays < 30)
                {
                    if (difference.TotalDays < 7)
                    {
                        if (difference.TotalDays < 1)
                        {
                            if (difference.TotalHours < 1)
                            {
                                if (difference.TotalMinutes < 2)
                                    return "1 minuto atrás";
                                else
                                    return difference.TotalMinutes + " minutos atrás";
                            }
                            else
                            {
                                if (difference.TotalHours < 2)
                                    return "1 hora atrás";
                                else
                                    return difference.TotalHours + " horas atrás";
                            }
                        }
                        else
                        {
                            if (difference.TotalDays < 2)
                                return "1 dia atrás";
                            else
                                return difference.TotalDays + " dias atrás";
                        }
                    }
                    else
                    {
                        if (difference.TotalDays == 7)
                            return "1 semana atrás";
                        else
                            return Math.Ceiling(difference.TotalDays / 7.0) + " semanas atrás";
                    }
                }
                else
                {
                    if (difference.TotalDays == 30)
                        return "1 mês atrás";
                    else
                        return Math.Round(difference.TotalDays / 30.0) + " meses atrás";
                }
            }
            else
            {
                if (difference.TotalDays == 365)
                    return "1 ano atrás";
                else
                    return Math.Round(difference.TotalDays / 365) + " anos atrás";
            }
        }
    }
}

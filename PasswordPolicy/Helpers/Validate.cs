using PasswordPolicy.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PasswordPolicy.Helpers
{
    public enum Required
    {
        Yes,
        No
    }
    public enum Property
    {
        Email,
        Password,
        UserId
    }

    public class TupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>>
    {
        public void Add(T1 value, T2 Requierd, T3 ValidationType)
        {
            Add(new Tuple<T1, T2, T3>(value, Requierd, ValidationType));
        }
    }


    public class Validate
    {
        public RequestObj RequestParameteres(TupleList<string, Required, Property> parameters)
        {
            RequestObj requestParams = new RequestObj();

            string errors = string.Empty;
            int userId = 0;
            string email = string.Empty;
            string password = string.Empty;

            foreach (var param in parameters)
            {
                switch (param.Item3)
                {
                    case Property.UserId:
                        if (param.Item2 == Required.Yes)
                        {
                            if (string.IsNullOrEmpty(param.Item1))
                            {
                                errors = "'userId' is required";
                            }
                        }

                        if (!string.IsNullOrEmpty(param.Item1))
                        {
                            if (!int.TryParse(param.Item1, out userId))
                            {
                                errors = "'userId' must be a numeric value";
                            }
                        }

                        requestParams.UserId = userId;
                        break;
                    // ========= Email
                    case Property.Email:

                        bool isEmail = Regex.IsMatch(param.Item1,
                                             @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                                             RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

                        if (param.Item2 == Required.Yes)
                        {
                            if (string.IsNullOrEmpty(param.Item1))
                            {
                                errors += ", 'email' is required";
                            }
                            else if (!isEmail)
                            {
                                errors += ", 'email' is not valid";
                            }
                        }

                        requestParams.Email = param.Item1;
                        break;
                    case Property.Password:

                        if (param.Item2 == Required.Yes)
                        {
                            if (string.IsNullOrEmpty(param.Item1))
                            {
                                errors += ", 'password' is required";
                            }

                        }

                        requestParams.Password = param.Item1;
                        break;

                    // Default
                    default:
                        break;


                }

            }

            requestParams.ParamsAreValid = (string.IsNullOrEmpty(errors) ? true : false);

            // Remove if start with ',' and then remove ' '
            if (!string.IsNullOrEmpty(errors))
            {
                if (errors.StartsWith(","))
                {
                    requestParams.ErrorMsg = errors.Remove(0, 2) + ".";
                }
                else
                {
                    requestParams.ErrorMsg = errors + ".";
                }
            }
            return requestParams;


        }
    }
}
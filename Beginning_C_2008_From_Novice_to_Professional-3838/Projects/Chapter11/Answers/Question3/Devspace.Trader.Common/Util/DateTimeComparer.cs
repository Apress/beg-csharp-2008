using System;

namespace Devspace.Commons.Trader.Util {
    public class DateTimeComparer {
        public static int Compare(DateTime orig, DateTime toCompare) {
            //GenerateOutput.Write( "DateTimeComparer.Compare", "Orig(" + orig.ToString() + ") ToCompare(" + toCompare.ToString() + ")");
            if(orig.Year < toCompare.Year) {
                return -1;
            }
            else if(orig.Year > toCompare.Year) {
                return 1;
            }
            else {
                if(orig.Month < toCompare.Month) {
                    return -1;
                }
                else if(orig.Month > toCompare.Month) {
                    return 1;
                }
                else {
                    if(orig.Day < toCompare.Day) {
                        return -1;
                    }
                    else if(orig.Day > toCompare.Day) {
                        return 1;
                    }
                    else {
                        if(orig.Hour < toCompare.Hour) {
                            return -1;
                        }
                        else if(orig.Hour > toCompare.Hour) {
                            return 1;
                        }
                        else {
                            if(orig.Minute < toCompare.Minute) {
                                return -1;
                            }
                            else if(orig.Minute > toCompare.Minute) {
                                return 1;
                            }
                            else {
                                if(orig.Second < toCompare.Second) {
                                    return -1;
                                }
                                else if(orig.Second > toCompare.Second) {
                                    return 1;
                                }
                                else {
                                    return 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static int CompareToMinute(DateTime orig, DateTime toCompare) {
            //GenerateOutput.Write( "DateTimeComparer.Compare", "Orig(" + orig.ToString() + ") ToCompare(" + toCompare.ToString() + ")");
            if(orig.Year < toCompare.Year) {
                return -1;
            }
            else if(orig.Year > toCompare.Year) {
                return 1;
            }
            else {
                if(orig.Month < toCompare.Month) {
                    return -1;
                }
                else if(orig.Month > toCompare.Month) {
                    return 1;
                }
                else {
                    if(orig.Day < toCompare.Day) {
                        return -1;
                    }
                    else if(orig.Day > toCompare.Day) {
                        return 1;
                    }
                    else {
                        if(orig.Hour < toCompare.Hour) {
                            return -1;
                        }
                        else if(orig.Hour > toCompare.Hour) {
                            return 1;
                        }
                        else {
                            if(orig.Minute < toCompare.Minute) {
                                return -1;
                            }
                            else if(orig.Minute > toCompare.Minute) {
                                return 1;
                            }
                            else {
								return 0;
                            }
                        }
                    }
                }
            }
        }
    }
}

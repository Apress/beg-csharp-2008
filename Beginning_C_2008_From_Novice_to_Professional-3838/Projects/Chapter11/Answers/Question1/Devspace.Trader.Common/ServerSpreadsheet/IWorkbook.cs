using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    public interface IWorksheetIdentifier {
        string FullnameIdentifier { get; }
        string Identifier { get; set; }
    }

    public abstract class WorksheetIdentifierBase<DerivedType> : IWorksheetIdentifier {
        public WorksheetIdentifierBase() {
        }

        public string FullnameIdentifier {
            get {
                return typeof(DerivedType).AssemblyQualifiedName;
            }
        }
        public string Identifier {
            get {
                return this.ToString();
            }
            set {
                ;
            }
        }
        public override string ToString() {
            return typeof(DerivedType).FullName;
        }
        public override bool Equals(object obj) {
            if (obj is DerivedType) {
                return true;
            }
            else {
                return false;
            }
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }

public interface IWorkbook : IDebug {
    IWorksheet<StateType> GetSheet<StateType>(string identifier);
    IWorksheetBase this[string identifier] { get; set; }
    string Identifier { get; }
}

    interface IMyType<TypeLevelScopeType> {
        TypeLevelScopeType GetMyValue();
        MethodLevelScopeType GetMyValue<MethodLevelScopeType>();
    }

}

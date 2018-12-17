using System;
using System.Collections.Generic;

namespace HashSetTask {
  class Program {
    static void Main(string[] args) {
      var myClassesList = new List<MyClass> {
        new MyClass { Id1 = 0, Id2 = 1, Description = "test-0" },
        new MyClass { Id1 = 0, Id2 = 1, Description = "test-1" },
        new MyClass { Id1 = 1, Id2 = 4, Description = "test-3" },
        new MyClass { Id1 = 2, Id2 = 2, Description = "test-4" },
        new MyClass { Id1 = 1, Id2 = 4, Description = "test-5" }
      };

      var hashSet = new HashSet<MyClass>();

      foreach (var myClass in myClassesList) {
        if (!hashSet.Add(myClass)) {
          Console.WriteLine($"id1 - {myClass.Id1} and id2 - {myClass.Id2} already exists");
        }
      }

      Console.ReadLine();
    }
  }

  class MyClass : IEquatable<MyClass> {
    public long Id1;
    public long Id2;
    public string Description;

    public override bool Equals(object obj) {
      return Equals(obj as MyClass);
    }

    public bool Equals(MyClass other) {
      return other != null &&
        Id1 == other.Id1 &&
        Id2 == other.Id2;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id1, Id2);
    }
  }

}
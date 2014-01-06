// Object.Create Shim
if (!Object.create) {
    Object.create = function (obj) {
        function theClass() { };
        theClass.prototype = obj;
        return new theClass();
    }
}

// inheritance interface
if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function theClass() { };
        theClass.prototype = Object.create(this);
        for (var prop in properties) {
            theClass.prototype[prop] = properties[prop];
        }

        theClass.prototype._super = this;
        return new theClass();
    }
}

// PrototypalOOP SchoolRepository classes
var PrototypalOOP = (function () {
    var Person = {
        init: function (fname, lname, age) {
            this.firstName = fname;
            this.lastName = lname;
            this.age = age;
        },
        toString: function () {
            return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
        }
    };

    var Student = Person.extend({
        init: function (fname, lname, age, grade) {
            this._super = Object.create(this._super);
            this._super.init(fname, lname, age);
            this.grade = grade;
        },
        toString: function () {
            return "{ " + this._super.toString() + ", Grade: " + this.grade + " }";
        }
    });

    var Teacher = Person.extend({
        init: function (fname, lname, age, speciality) {
            this._super = Object.create(this._super);
            this._super.init(fname, lname, age);
            this.speciality = speciality;
        },
        toString: function () {
            return "{ " + this._super.toString() + ", Speciality: " + this.speciality + " }";
        }
    });

    var StudentsClass = {
        init: function (name, teacher, capacity) {
            this.name = name;
            this.formTeacher = teacher;
            this.capacity = (capacity | 0) || 30;
            this.students = [];
        },
        addStudent: function (newStudent) {
            if (this.students.length >= this.capacity) {
                throw new Error("The class is full");
            }

            this.students.push(newStudent);
        },
        toString: function () {
            var output = "Classname: " + this.name +
                ", Form-teacher: " + this.formTeacher.toString();
            if (this.students.length) {
                output += ", Students: [ ";
                for (i = 0, len = this.students.length; i < len; i++) {
                    if (i > 0) {
                        output += ", ";
                    }
                    output += this.students[i].toString();
                }
                output += " ]";
            }

            return "{ " + output + " }";
        }
    };

    var School = {
        init: function (name, town) {
            this.name = name;
            this.town = town;
            this.classes = [];
        },
        addClass: function (newClass) {
            this.classes.push(newClass);
        },
        toString: function () {
            var output = "Name: " + this.name + ", Town: " + this.town;
            if (this.classes.length) {
                output += ", Classes: [ ";
                for (var i = 0, len = this.classes.length; i < len; i++) {
                    if (i > 0) {
                        output += ", ";
                    }
                    output += this.classes[i].toString();
                }
                output += " ]";
            }

            return output;
        }
    };

    return {
        Student: Student,
        Teacher: Teacher,
        StudentsClass: StudentsClass,
        School: School
    }
})();
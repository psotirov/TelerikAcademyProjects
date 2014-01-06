// Class.create shim
var Class = (function () {
    function createClass(properties) {
        var theClass = function () {
            if (this._superConstructor) {
                this._super = new this._superConstructor(arguments);
            }

            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            theClass.prototype[prop] = properties[prop];
        }

        if (!theClass.prototype.init) {
            theClass.prototype.init = function () { }
        }

        return theClass;
    }

    return {
        create: createClass
    }
})();

// inheritance interface
Function.prototype.inherit = function (parent) {
    var oldPrototype = this.prototype;
    this.prototype = new parent();
    this.prototype._superConstructor = parent;
    for (var prop in oldPrototype) {
        this.prototype[prop] = oldPrototype[prop];
    }
}


// ClassicalOOP SchoolRepository classes
var ClassicalOOP = (function () {
    var Person = Class.create({
        init: function (fname, lname, age) {
            this.firstName = fname;
            this.lastName = lname;
            this.age = age;
        },
        toString: function () {
            return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
        }
    });

    var Student = Class.create({
        init: function (fname, lname, age, grade) {
            this._super.init(fname, lname, age);
            this.firstName = this._super.firstName;
            this.lastName = this._super.lastName;
            this.age = this._super.age;
            this.grade = grade;
        },
        toString: function () {
            return "{ " + this._super.toString() + ", Grade: " + this.grade + " }";
        }
    });
    Student.inherit(Person);

    var Teacher = Class.create({
        init: function (fname, lname, age, speciality) {
            this._super.init(fname, lname, age);
            this.firstName = this._super.firstName;
            this.lastName = this._super.lastName;
            this.age = this._super.age;
            this.speciality = speciality;
        },
        toString: function () {
            return "{ " + this._super.toString() + ", Speciality: " + this.speciality + " }";
        }
    });
    Teacher.inherit(Person);
    
    var StudentsClass = Class.create({
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
    });

    var School = Class.create({
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
    });

    return {
        Student: Student,
        Teacher: Teacher,
        StudentsClass: StudentsClass,
        School: School
    }
})();


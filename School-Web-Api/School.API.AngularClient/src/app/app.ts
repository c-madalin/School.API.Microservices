import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';   
import { HttpClientModule } from '@angular/common/http';
import { StudentService, Student, CreateStudentDto } from './student-service/student';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule], 
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class AppComponent implements OnInit {
  studenti: Student[] = [];

  studentNou: CreateStudentDto = {
    nume: '',
    nota: 0
  };

  constructor(private studentService: StudentService) {}

  ngOnInit() {
    this.incarcaStudentii();
  }

  incarcaStudentii() {
    this.studentService.getStudents().subscribe({
      next: (data) => {
        this.studenti = data;
        console.log('Studenti incarcati:', data);
      },
      error: (err) => console.error('Eroare la incarcare:', err)
    });
  }

  adauga() {
    if (this.studentNou.nume.length < 3) {
      alert('Numele trebuie sa aiba minim 3 caractere!');
      return;
    }

    this.studentService.addStudent(this.studentNou).subscribe({
      next: () => {
        alert('Student adaugat cu succes!');
        this.incarcaStudentii(); 
        this.studentNou = { nume: '', nota: 0 };
      },
      error: (err) => alert('Eroare: ' + err.error)
    });
  }

  sterge(id: number) {
    if(confirm('Esti sigur ca vrei sa stergi acest student?')) {
      this.studentService.deleteStudent(id).subscribe({
        next: () => this.incarcaStudentii(),
        error: (err) => alert('Eroare la stergere!')
      });
    }
  }
}
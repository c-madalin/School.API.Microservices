import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Student {
  id: number;
  nume: string;
  medie: number; 
}

export interface CreateStudentDto {
  nume: string;
  nota: number;
}

@Injectable({
  providedIn: 'root'
})
export class StudentService {
 
  private apiUrl = 'https://localhost:7179/api/students'; 

  constructor(private http: HttpClient) { }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.apiUrl);
  }

  addStudent(student: CreateStudentDto): Observable<any> {
    return this.http.post(this.apiUrl, student);
  }

  deleteStudent(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
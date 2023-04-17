import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Car } from '../models/car.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MakeDropdownService {
  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllMakes(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseApiUrl + '/api/car/getAllMakes');
  }

  searchCars(selectedMake: string): Observable<Car[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<Car[]>(this.baseApiUrl + '/api/car/GetModelsForMake', JSON.stringify(selectedMake), httpOptions);
  }
}

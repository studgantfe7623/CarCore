import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Car } from '../models/car.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarlistService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }


  getModelsForMake(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseApiUrl + '/api/car/GetModelsForMake');
  }
}

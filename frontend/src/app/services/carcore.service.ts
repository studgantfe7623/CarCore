import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Car } from '../models/car.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarcoreService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllMakes(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseApiUrl + '/api/car/getAllMakes');
  }

  getModelsForMake(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseApiUrl + '/api/car/GetModelsForMake');
  }
}

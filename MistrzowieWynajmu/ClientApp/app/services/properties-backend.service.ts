import { Property } from '../models/Property';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export abstract class PropertiesBackendService {
    abstract addProperty(newProperty: Property): Observable<number>;

    abstract getProperty(propertyId: number): Observable<Property>;

    abstract deleteProperty(propertyId: number): Observable<number>;

    abstract getProperties(): Observable<Property[]>;

    abstract updateProperty(updatedProperty: Property): Observable<number>;

}
import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface ReferenceNumber {
  type: string;
  value: string;
}

export interface Commodity {
  description: string;
  weight: number;
  handlingInstructions: string;
}

export interface CreateLoadRequest {
  customerId: string;
  referenceNumbers: ReferenceNumber[];
  commodities: Commodity[];
}

export interface SaveLoadDraftRequest {
  customerId?: string;
  referenceNumbers?: ReferenceNumber[];
  commodities?: Commodity[];
}

export interface LoadResponse {
  id: string;
  shipmentId: string;
  status: string;
}

export interface SaveDraftResponse {
  id: string;
  message: string;
}

@Injectable({
  providedIn: 'root',
})
export class LoadService {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/loads`;

  createLoad(load: CreateLoadRequest): Observable<LoadResponse> {
    return this.http.post<LoadResponse>(this.apiUrl, load);
  }

  saveDraft(draft: SaveLoadDraftRequest): Observable<SaveDraftResponse> {
    return this.http.post<SaveDraftResponse>(`${this.apiUrl}/draft`, draft);
  }
}

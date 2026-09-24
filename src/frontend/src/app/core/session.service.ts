import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SessionService {
  private readonly storageKey = 'user_session_token';

  ensureSessionToken(): string {
    const token = `sess_${Date.now()}_${Math.random().toString(16).slice(2)}`;
    localStorage.setItem(this.storageKey, token);
    return token;
  }
}

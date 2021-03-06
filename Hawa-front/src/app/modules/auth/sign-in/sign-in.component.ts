import { Component, OnInit } from '@angular/core';
import { SessionService } from '../../../shared/service/session.service';
import { Router } from '@angular/router';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss'],
})
export class SignInComponent implements OnInit {

  constructor(
    private sessionService: SessionService,
    private router: Router,
  ) { }

  ngOnInit() {
    if (this.sessionService.currentSession) {
      this.router.navigate(['/pages/infor-search/list']);
    }
  }

}

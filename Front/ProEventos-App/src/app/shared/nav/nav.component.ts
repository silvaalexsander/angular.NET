import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  showMenu(): boolean{
    var teste = this.router.url !== '/user/login' && this.router.url !== '/user/register';
    return teste;
  }
}

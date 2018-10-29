import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    title: string = "to jest tytu³ stronki";
    isCool: boolean = true;
}

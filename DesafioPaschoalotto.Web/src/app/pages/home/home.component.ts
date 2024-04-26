import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user';
import { DatePipe, NgFor } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgFor, RouterLink, RouterOutlet, DatePipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  users?: User[];

  constructor(private userService: UserService) {

  }



  ngOnInit() {

    this.userService.getUsers().subscribe((data) => {
      this.users = data
    });

  }

  onExportExcel() {

    this.userService.exportExcel().subscribe((data: any) => {
      var file = new Blob([data], {
        type: data.type
      })

      const blob = window.URL.createObjectURL(file);
      const link = document.createElement('a');
      link.href = blob;
      link.download = 'report.xlsx';
      link.click();

      window.URL.revokeObjectURL(blob);
      link.remove();
    })
  }


  onEditUser(user: User) {

  }


}

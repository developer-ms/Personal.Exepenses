//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SpentService } from '../spent.service';

@Component({
    selector: 'app-spent-container-create',
    templateUrl: './spent-container-create.component.html',
    styleUrls: ['./spent-container-create.component.css'],
})
export class SpentContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private spentService: SpentService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.spentService.initVM();
    }

    ngOnInit() {

       
    }

}

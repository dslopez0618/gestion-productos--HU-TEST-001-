import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {
  productForm: FormGroup;
  isEditMode = false;
  productId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      price: [0, [Validators.required, Validators.min(0.01)]]
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.productId = +id;
        this.productService.getProductById(this.productId).subscribe({
          next: (product) => {
            this.productForm.patchValue(product);
          },
          error: (error) => console.error('Error loading product:', error)
        });
      }
    });
  }

  onSubmit(): void {
    if (this.productForm.invalid) return;

    const product = this.productForm.value;
    if (this.isEditMode && this.productId) {
      this.productService.updateProduct(this.productId, product).subscribe({
        next: () => this.router.navigate(['/products']),
        error: (error) => console.error('Error updating product:', error)
      });
    } else {
      this.productService.createProduct(product).subscribe({
        next: () => this.router.navigate(['/products']),
        error: (error) => console.error('Error creating product:', error)
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/products']);
  }
}


// @dslopez0618
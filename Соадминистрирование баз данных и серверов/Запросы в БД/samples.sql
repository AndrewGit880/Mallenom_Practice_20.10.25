CREATE TABLE samples (
    sample_id SERIAL PRIMARY KEY, 
    sample_name VARCHAR(255) NOT NULL, 
    material_type VARCHAR(255),     
    production_date DATE             
);
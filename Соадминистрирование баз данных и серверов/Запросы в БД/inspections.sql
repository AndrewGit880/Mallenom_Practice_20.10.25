CREATE TABLE inspections (
    inspection_id SERIAL PRIMARY KEY,
    sample_id INT REFERENCES samples(sample_id), 
    inspection_date DATE NOT NULL,    
    inspector_name VARCHAR(255)        
);
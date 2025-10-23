CREATE TABLE defects (
    defect_id SERIAL PRIMARY KEY,     
    inspection_id INT REFERENCES inspections(inspection_id), 
    defect_type VARCHAR(255),         
    defect_size NUMERIC,               
    defect_location VARCHAR(255),      
    severity VARCHAR(50)               
);
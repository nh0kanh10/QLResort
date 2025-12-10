-- =====================================================
-- MIGRATE EXISTING INVOICE CODES: HD### → HD-DP-###
-- =====================================================
-- This script updates all existing invoice codes from format HD### to HD-DP-###
-- Assumes all existing invoices are for room bookings

USE QLResort;
GO

-- Step 1: Backup existing data (optional but recommended)
SELECT * INTO HoaDon_Backup_BeforeMigration FROM HoaDon;
GO

-- Step 2: Update invoice codes
-- Pattern: HD001 → HD-DP-001, HD002 → HD-DP-002, etc.
UPDATE HoaDon
SET MaHD = 'HD-DP-' + RIGHT('000' + SUBSTRING(MaHD, 3, LEN(MaHD) - 2), 3)
WHERE MaHD LIKE 'HD[0-9]%'  -- Only update codes matching HD### pattern
  AND MaHD NOT LIKE 'HD-DP-%'  -- Skip already migrated codes
  AND MaHD NOT LIKE 'HD-SK-%'; -- Skip event codes
GO

-- Step 3: Verify migration
SELECT 
    CASE 
        WHEN MaHD LIKE 'HD-DP-%' THEN 'Room Booking Invoice'
        WHEN MaHD LIKE 'HD-SK-%' THEN 'Event Invoice'
        ELSE 'Unknown Format'
    END AS InvoiceType,
    COUNT(*) AS Count
FROM HoaDon
GROUP BY 
    CASE 
        WHEN MaHD LIKE 'HD-DP-%' THEN 'Room Booking Invoice'
        WHEN MaHD LIKE 'HD-SK-%' THEN 'Event Invoice'
        ELSE 'Unknown Format'
    END;
GO

PRINT '✅ Invoice code migration completed!';
PRINT 'HD### → HD-DP-###';
GO

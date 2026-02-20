-- Create users table
CREATE TABLE IF NOT EXISTS users (
    user_id SERIAL PRIMARY KEY,
    user_name VARCHAR(255) UNIQUE NOT NULL,
    user_password VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create get_user_info function (replaces MySQL stored procedure)
CREATE OR REPLACE FUNCTION get_user_info(p_user_name VARCHAR(255))
RETURNS TABLE(
    user_id INT,
    user_name VARCHAR(255),
    user_password VARCHAR(255),
    created_at TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT
        u.user_id,
        u.user_name,
        u.user_password,
        u.created_at
    FROM users u
    WHERE u.user_name = p_user_name;
END;
$$ LANGUAGE plpgsql;

-- Create change_user_password function
CREATE OR REPLACE FUNCTION change_user_password(p_user_id INT, p_user_password VARCHAR(255))
RETURNS VOID AS $$
BEGIN
    UPDATE users
    SET user_password = p_user_password
    WHERE user_id = p_user_id;
END;
$$ LANGUAGE plpgsql;

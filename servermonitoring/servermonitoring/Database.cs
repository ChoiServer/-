using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace servermonitoring
{
    public class Database : IDisposable
    {
        #region 프로퍼티
        private SqlConnection Cnn;
        public SqlConnection Connection
        {
            get
            {
                return Cnn;
            }
        }

        public SqlTransaction tran = null;
        private string _userID = "sa";
        private readonly string _passWord_old = "dsr";
        private string _passWord = "dsr";
        private readonly string _severIP;
        private readonly string _catalog;


        public string DataSourceString
        {
            get
            {
                if(_severIP == "10.10.10.8")
                    return String.Format("Data Source={0};database={1};user id={2};password={3}", _severIP, _catalog, _userID, _passWord_old);
                else
                    return String.Format("Data Source={0};database={1};user id={2};password={3}", _severIP, _catalog, _userID, _passWord);
            }
        }

        public bool IsConnect
        {
            get
            {
                return Cnn.State == ConnectionState.Connecting;
            }
        }

        public bool IsOpen
        {
            get
            {
                return Cnn.State == ConnectionState.Open;
            }
        }

 

        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (Cnn != null)
                {
                    Cnn.Dispose();
                    Cnn = null;
                }
        }
        ~Database()
        {
            Dispose(false);
        }
        #endregion


        public Database()
        {
            _severIP = ConfigurationManager.AppSettings.Get("SeverIP");
            _catalog = ConfigurationManager.AppSettings.Get("Catalog");
        }

        public Database(String SeverIP, String Catalog)
        {
            
            _severIP = SeverIP;
            //_userID = UserID;
            _catalog = Catalog;
   
        }

        public Database(String SeverIP, String Catalog, string userID, string Password)
        {

            _severIP = SeverIP;
            //_userID = UserID;
            _catalog = Catalog;

            _userID = userID;
            _passWord = Password;
        }


        public bool DBConn()
        {
            try 
            {
                Cnn = new SqlConnection(DataSourceString);
                Cnn.Open();
              
            }
            catch (SqlException e)
            {
                //string errMsg = e.ToString();
                return false;
            }

            return true;
            
        }
        
        
        public bool DBConn(string _DataSourceString)
        {
            try
            {
                Cnn = new SqlConnection(_DataSourceString);
                Cnn.Open();

            }
            catch (SqlException e)
            {
                //string errMsg = e.ToString();
                return false;
            }

            return true;

        }


        public bool DBOpen()
        {
            if (Cnn == null)
            {
                DBConn();
            }
            try
            {
                if (Cnn.State != ConnectionState.Open)
                {
                    Cnn.Open();
              
                }
            }
            catch (SqlException e)
            {
                //string errMsg = e.ToString();
                return false;
            }

            return true;
        }

        public bool DBClose()
        {
            try
            {
                if (Cnn != null && Cnn.State == ConnectionState.Open)
                    Cnn.Close();
            }
            catch (SqlException e)
            {
                return false;
            }
            return true;
        }



        // strCmm 의 쿼리를 받아서 dataset으로 결과값 리턴
        public DataSet GetDataSetTxtQuery(string strCmm)        
        {
            using (SqlDataAdapter Adt = new SqlDataAdapter(strCmm, Cnn))
            {
                Adt.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet("DATA");
                Adt.Fill(ds);
                return ds;
            }
        }

        public void GetDataSetTxtQuery(string strCmm, DataSet ds)
        {
            using (SqlDataAdapter Adt = new SqlDataAdapter(strCmm, Cnn))
            {
                if (tran != null)
                    Adt.SelectCommand.Transaction = tran;   
                Adt.SelectCommand.CommandType = CommandType.Text;
                Adt.Fill(ds, "DATA");
            }
        }

        /// <summary>
        /// 데이터 1행을 배열로 받음
        /// </summary>
        /// <param name="strCmm"></param>
        /// <returns></returns>
        public string[] GetArrayTextQuery(string strCmm)
        {
            DataTable dt = GetDataTableTxtQuery(strCmm);
            if (dt == null || dt.Rows.Count == 0 ) return null;
            DataRow dr = dt.Rows[0];
            string[] rtn = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                rtn[i] = dr[i].ToString();
            }

            return rtn;
        }


        /// <summary>
        /// 데이터 1행을 datarow로 받음
        /// </summary>
        /// <param name="strCmm"></param>
        /// <returns></returns>
        public DataRow Get1RowTxtQuery(string strCmm)
        {
            DataTable dt = GetDataTableTxtQuery(strCmm);
            if (dt == null || dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return dr;
        }


        public DataTable GetDataTableTxtQuery(string strCmm)
        {
            using (SqlDataAdapter Adt = new SqlDataAdapter(strCmm, Cnn))
            {
                if (tran != null)
                    Adt.SelectCommand.Transaction = tran;
                Adt.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                Adt.Fill(dt);
                if (dt.Rows.Count == 0) return null;
                return dt;
            }
        }


        // strCmm 의 쿼리를 받아서 "A,B,20,20.5/B,C,30,10.5"형태의 string으로 리턴
        // strCmm 의 쿼리를 받아서 배열String으로 리턴
        public String[,] GetStringTxtQuery(string strCmm)
        {
           
            using (SqlDataAdapter Adt = new SqlDataAdapter(strCmm, Cnn))
            {
                Adt.SelectCommand.CommandType = CommandType.Text;
                if (tran != null)
                    Adt.SelectCommand.Transaction = tran;
                DataTable dt = new DataTable();
                Adt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    String[,] rtnString = new String[dt.Rows.Count, dt.Columns.Count];


                    for (int i = 0; i < dt.Rows.Count; i++)
                        for (int j = 0; j < dt.Columns.Count; j++)
                            rtnString[i, j] = dt.Rows[i][j].ToString();
                    return rtnString;
                }
                else
                    return null;
            }
            
        }

        // strCmm 의 쿼리를 받아서 object으로 리턴
        //  호출한 쪽에서 Convert.ToInt32()등을 사용해서 처리하면됨
        public object GetScalarTxtQuery(string strCmm)
        {   
            object id;
            using (SqlCommand cmd = new SqlCommand(strCmm, Cnn)) 
            {
                if (tran != null)
                    cmd.Transaction = tran;
                //id = Convert.ToInt32(cmd.ExecuteScalar());
                id = cmd.ExecuteScalar();
            }

            return id;
        }

        // 쿼리를 받아 DataRow 로 반환
        // 제일 첫 한줄만  <-- 중요함...
        // string 배열로 던질경우 필드명으로 찾을수 없어서 불편하므로
        // 받은 row["필드명"]으로 사용할것
        // 

        //public DataRow GetData1RowTxtQuery(string strQry)
        //{
        //    DataTable dt = GetDataTableTxtQuery(strQry);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        DataRow curRow = dt.Rows[0];
        //        return curRow;
        //    }
        //    else
        //        return null;
        //}

        /// <summary>
        ///	SP실행후에 결과값을 DataSet으로 Return함
        /// </summary>
        /// <param name="strProc">SP이름</param>
        /// <param name="strParams">SP 파라메터들의 값</param>
        /// <returns>결과값을 DataSet으로 리턴</returns>
        public DataSet GetDataSetQuery(string strProc, params string[] strParams)
        {

            DataSet ds = new DataSet();
            GetDataSetQuery(strProc, ds, strParams);
            return ds;
        }

        /// <summary>
        /// SP실행후에 결과값을 DataSet으로 Return함
        /// </summary>
        /// <param name="strProc">SP이름</param>
        /// <param name="ds">결과값을 받을 DataSet</param>
        /// <param name="strParams">SP 파라메터들의 값</param>
        public void GetDataSetQuery(string strProc, DataSet ds, params string[] strParams)
        {
            GetDataSetQuery(strProc, ds, "DATA", strParams);
        }

        /// <summary>
        /// SP실행후에 결과값을 DataSet으로 Return함
        /// </summary>
        /// <param name="strProc">SP이름</param>
        /// <param name="ds">결과값을 받을 DataSet</param>
        /// <param name="strParams">SP 파라메터들의 값</param>
        public void GetDataSetQuery(string strProc, DataSet ds, string tablename, params string[] strParams)
        {
            using (SqlDataAdapter Adt = new SqlDataAdapter(strProc, Cnn))
            {
                Adt.SelectCommand.CommandType = CommandType.StoredProcedure;
                if ((strParams != null) && (strParams.Length != 0))  //파라미터 처리함수 수행.
                    Params(Adt, strProc, strParams);
                Adt.Fill(ds, tablename);
            }
        }

        /// <summary>
        /// SP실행후에 결과값을 SqlDataReader로 Return함
        /// </summary>
        /// <param name="strProc">SP이름</param>
        /// <param name="strParams">SP 파라메터들의 값</param>
        /// <returns>결과값을 SqlDataReader로 리턴</returns>
        public SqlDataReader GetReaderQuery(string strProc, params string[] strParams)
        {
            SqlCommand Cmm = new SqlCommand(strProc, Cnn) { CommandType = CommandType.StoredProcedure };
            if ((strParams != null) && (strParams.Length != 0))  //파라미터 처리함수 수행.
                Params(Cmm, strProc, strParams);
            SqlDataReader dr = Cmm.ExecuteReader();
            //Close();
            return dr;      // SqlDataReader를꼭 Close해야됨
        }

        public SqlDataReader GetReaderQueryTxt(string strCmm)
        {
            SqlCommand Cmm = new SqlCommand(strCmm, Cnn) { CommandType = CommandType.Text };
            SqlDataReader dr = Cmm.ExecuteReader();
            //Close();
            return dr;      // SqlDataReader를꼭 Close해야됨
        }

        // strCmm 의 쿼리를 받아서 object으로 리턴
        //  호출한 쪽에서 Convert.ToInt32()등을 사용해서 처리하면됨
        public object GetScalarSPQuery(string commandText, params SqlParameter[] commandParameters)
        {
            if (Cnn == null)
                throw new ArgumentNullException("connection");

            object id;
            using (SqlCommand cmd = new SqlCommand(commandText, Cnn))
            {
                PrepareCommand(cmd, Cnn, (SqlTransaction)null, CommandType.StoredProcedure, commandText, commandParameters);
                id = cmd.ExecuteScalar();

            }
            return id;
        }

        /// <summary>
        /// UPDATE, DELETE , INSERT같은 SQL의 SP를 실행함
        /// </summary>
        /// <param name="strCmm">SP이름</param>
        public int NonQueryTxt(string strCmm)
        {
            int cnt;
            using (SqlCommand Cmm = new SqlCommand(strCmm, Cnn) { CommandType = CommandType.Text, Transaction = tran })
            {
                cnt = Cmm.ExecuteNonQuery();
            }
            return cnt;
        }

        /// <summary>
        /// UPDATE, DELETE , INSERT같은 SQL의 SP를 실행함
        /// </summary>
        /// <param name="strCmm">SP이름</param>
        public int NonQueryTxt(string strCmm, int _TimeOut)
        {
            int cnt;
            using (SqlCommand Cmm = new SqlCommand(strCmm, Cnn) { CommandType = CommandType.Text, Transaction = tran })
            {
                Cmm.CommandTimeout = _TimeOut;
                cnt = Cmm.ExecuteNonQuery();
            }
            return cnt;
        }

        /// <summary>
        /// UPDATE, DELETE , INSERT같은 SQL의 SP를 실행함
        /// </summary>
        /// <param name="strProc">SP이름</param>
        /// <param name="strParams">SP 파라메터들의 값</param>
        public int NonQuery(string strProc, params string[] strParams)
        {
            using (SqlCommand Cmm = new SqlCommand(strProc, Cnn) { CommandType = CommandType.StoredProcedure, Transaction = tran })
            {
                if ((strParams != null) && (strParams.Length != 0))
                    Params(Cmm, strProc, strParams);
                Cmm.Parameters.Add(CreateRetParam("ReturnValue"));
                Cmm.ExecuteNonQuery();
                int result = (int)Cmm.Parameters["ReturnValue"].Value;
                return result;
            }
        }


        public static SqlParameter CreateRetParam(string paramName)
        {
            // SQL Server의 리턴 값은 항상 Int 타입만을 사용하므로 이 함수는 굳이 여러 개의 인자를 요구할 필요가 없다.
            // 이는 SQL Server의 리턴 값을 받아올 수 있다.
            SqlParameter param = new SqlParameter(paramName, SqlDbType.Int, 4) { Direction = ParameterDirection.ReturnValue };

            return param;
        }


        // sp의 파라미터값의 변수타입및 길이를 알아내냄
        private void Params(Object obj, string procName, params string[] objParam)
        {
            using (DataSet dsParams = GetDataSetOfParams(procName))
            {
                int count = 0;
                //for(int i = 0 ; i < ds.Tables[1].Rows.Count ; i++)
                foreach (DataRow row in dsParams.Tables[1].Rows)
                {
                    SqlParameter Spt = new SqlParameter() { ParameterName = row[0].ToString() /*파라미터 이름*/ };
                    if (row[1].ToString() == "numeric")
                        Spt.SqlDbType = SqlDbType.Decimal;
                    else
                        Spt.SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), row[1].ToString(), true); //열거형으로 형변환해서 파라미터 데이타 타입				
                    Spt.Size = Convert.ToInt32(row[2].ToString());
                    //Spt.Precision = Convert.ToByte(row[3].ToString());
                    if (row[6].ToString() == "0")
                    {
                        Spt.Direction = ParameterDirection.Input;
                        Spt.Value = objParam[count];
                        count++;
                    }
                    else
                    {
                        Spt.Direction = ParameterDirection.Output;
                    }
                    if (obj is SqlDataAdapter)
                        ((SqlDataAdapter)obj).SelectCommand.Parameters.Add(Spt); //파라미터 등록
                    if (obj is SqlCommand)
                        ((SqlCommand)obj).Parameters.Add(Spt); //파라미터 등록
                }
            }
        }

        private DataSet GetDataSetOfParams(string procName)
        {
            //1. sp_params 스토어드프로시저를 실행-----------------------------
            using (SqlDataAdapter Adt = new SqlDataAdapter("sp_params", Cnn))
            {
                Adt.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter Spt = new SqlParameter("@objname", SqlDbType.NVarChar, 500) { Value = procName };
                Adt.SelectCommand.Parameters.Add(Spt);
                DataSet ds = new DataSet();
                Adt.Fill(ds);
                //데이타 셋에 두개의 테이블이 들어간다.
                //-----------------------------------------------------------------
                return ds;
            }
        }

        ///
        public void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction,
            CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            command.Connection = connection;

            command.CommandText = commandText;

            if (transaction != null)
            {
                if (transaction.Connection == null)
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            command.CommandType = commandType;

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }


        public void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }
        
        


    }
}


/*

create proc sp_params
	@objname nvarchar(776) = NULL		-- object name we're after
as
	-- PRELIMINARY
	set nocount on
	declare	@dbname	sysname

	-- OBTAIN DISPLAY STRINGS FROM spt_values UP FRONT --
	declare @no varchar(35), @yes varchar(35), @none varchar(35)
	select @no = name from master.dbo.spt_values where type = 'B' and number = 0
	select @yes = name from master.dbo.spt_values where type = 'B' and number = 1
	select @none = name from master.dbo.spt_values where type = 'B' and number = 2

	-- If no @objname given, give a little info about all objects.
	if @objname is null
	begin
		-- DISPLAY ALL SYSOBJECTS --
        select
            'Name'          = o.name,
            'Owner'         = user_name(uid),
            'Object_type'   = substring(v.name,5,31)
        from sysobjects o, master.dbo.spt_values v
        where o.xtype = substring(v.name,1,2) collate database_default and v.type = 'O9T'
        order by Object_type desc, Name asc

		print ' '

		-- DISPLAY ALL USER TYPES
		select
			'User_type'		= name,
			'Storage_type'	= type_name(xtype),
			'Length'		= length,
			'Prec'			= TypeProperty(name, 'precision'),
			'Scale'			= TypeProperty(name, 'scale'),
			'Nullable'		= case when TypeProperty(name, 'AllowsNull') = 1
											then @yes else @no end,
			'Default_name'	= isnull(object_name(tdefault), @none),
			'Rule_name'		= isnull(object_name(domain), @none),
			'Collation'		= collation
		from systypes
		where xusertype > 256
		order by name

		return(0)
	end

	-- Make sure the @objname is local to the current database.
	select @dbname = parsename(@objname,3)

	if @dbname is not null and @dbname <> db_name()
		begin
			raiserror(15250,-1,-1)
			return(1)
		end

	-- @objname must be either sysobjects or systypes: first look in sysobjects
	declare @objid int
	declare @sysobj_type char(2)
	select @objid = id, @sysobj_type = xtype from sysobjects where id = object_id(@objname)

	-- IF NOT IN SYSOBJECTS, TRY SYSTYPES --
	if @objid is null
	begin
		-- UNDONE: SHOULD CHECK FOR AND DISALLOW MULTI-PART NAME
		select @objid = xusertype from systypes where name = @objname

		-- IF NOT IN SYSTYPES, GIVE UP
		if @objid is null
		begin
			select @dbname=db_name()
			raiserror(15009,-1,-1,@objname,@dbname)
			return(1)
		end

		-- DATA TYPE HELP (prec/scale only valid for numerics)
		select
			'Type_name'		= name,
			'Storage_type'	= type_name(xtype),
			'Length'		= length,
			'Prec'			= TypeProperty(name, 'precision'),
			'Scale'			= TypeProperty(name, 'scale'),
			'Nullable'		= case when allownulls=1 then @yes else @no end,
			'Default_name'	= isnull(object_name(tdefault), @none),
			'Rule_name'		= isnull(object_name(domain), @none),
			'Collation'		= collation
		from systypes
		where xusertype = @objid

		return(0)
	end

	-- FOUND IT IN SYSOBJECT, SO GIVE OBJECT INFO
	select
		'Name'				= o.name,
		'Owner'				= user_name(uid),
        'Type'              = substring(v.name,5,31),
		'Created_datetime'	= o.crdate
	from sysobjects o, master.dbo.spt_values v
	where o.id = @objid and o.xtype = substring(v.name,1,2) collate database_default and v.type = 'O9T'

	print ' '

	-- DISPLAY COLUMN IF TABLE / VIEW
	if @sysobj_type in ('S ','U ','V ','TF','IF')
	begin

		-- SET UP NUMERIC TYPES: THESE WILL HAVE NON-BLANK PREC/SCALE
		declare @numtypes nvarchar(80)
		select @numtypes = N'tinyint,smallint,decimal,int,real,money,float,numeric,smallmoney'

		-- INFO FOR EACH COLUMN
		print ' '
		select
			'Column_name'			= name,
			'Type'					= type_name(xusertype),
			'Computed'				= case when iscomputed = 0 then @no else @yes end,
			'Length'				= convert(int, length),
			'Prec'					= case when charindex(type_name(xtype), @numtypes) > 0
										then convert(char(5),ColumnProperty(id, name, 'precision'))
										else '     ' end,
			'Scale'					= case when charindex(type_name(xtype), @numtypes) > 0
										then convert(char(5),OdbcScale(xtype,xscale))
										else '     ' end,
			'Nullable'				= case when isnullable = 0 then @no else @yes end,
			'TrimTrailingBlanks'	= case ColumnProperty(@objid, name, 'UsesAnsiTrim')
										when 1 then @no
										when 0 then @yes
										else '(n/a)' end,
			'FixedLenNullInSource'	= case
						when type_name(xtype) not in ('varbinary','varchar','binary','char')
							Then '(n/a)'
						When status & 0x20 = 0 Then @no
						Else @yes END,
			'Collation'		= collation
		from syscolumns where id = @objid and number = 0 order by colid

		-- IDENTITY COLUMN?
		if @sysobj_type in ('S ','U ','V ','TF')
		begin
			print ' '
			declare @colname sysname
			select @colname = name from syscolumns where id = @objid
						and colstat & 1 = 1
			select
				'Identity'				= isnull(@colname,'No identity column defined.'),
				'Seed'					= ident_seed(@objname),
				'Increment'				= ident_incr(@objname),
				'Not For Replication'	= ColumnProperty(@objid, @colname, 'IsIDNotForRepl')
			-- ROWGUIDCOL?
			print ' '
			select @colname = null
			select @colname = name from syscolumns where id = @objid and number = 0
						and ColumnProperty(@objid, name, 'IsRowGuidCol') = 1
			select 'RowGuidCol' = isnull(@colname,'No rowguidcol column defined.')
		end
	end

	-- DISPLAY PROC PARAMS
	if @sysobj_type in ('P ') --RF too?
	begin
		-- ANY PARAMS FOR THIS PROC?
		if exists (select id from syscolumns where id = @objid)
		begin
			-- INFO ON PROC PARAMS
			print ' '
			select
				'Parameter_name'	= name,
				'Type'				= type_name(xusertype),
                'Length'			= length,
                'Prec'				= case when type_name(xtype) = 'uniqueidentifier' then xprec
										else OdbcPrec(xtype, length, xprec) end,
                'Scale'				= OdbcScale(xtype,xscale),
                'Param_order'		= colid,
	  'Isoutparam' 	              = isoutparam,
				'Collation'		= collation

			from syscolumns where id = @objid
		end
	end

	-- DISPLAY TABLE INDEXES & CONSTRAINTS
	if @sysobj_type in ('S ','U ')
	begin
		print ' '
		execute sp_objectfilegroup @objid
		print ' '
		execute sp_helpindex @objname
		print ' '
		execute sp_helpconstraint @objname,'nomsg'
		if (select count(*) from sysdepends where depid = @objid and deptype = 1) = 0
		begin
			raiserror(15647,-1,-1) -- 'No views with schemabinding reference this table.'
		end
		else
		begin
            select distinct 'Table is referenced by views' = obj.name from sysobjects obj, sysdepends deps
				where obj.xtype ='V' and obj.id = deps.id and deps.depid = @objid
					and deps.deptype = 1 group by obj.name

		end
	end
	else if @sysobj_type in ('V ')
	begin
		-- VIEWS DONT HAVE CONSTRAINTS, BUT PRINT THESE MESSAGES BECAUSE 6.5 DID
		print ' '
		raiserror(15469,-1,-1) -- No constraints defined
		print ' '
		raiserror(15470,-1,-1) --'No foreign keys reference this table.'
		execute sp_helpindex @objname
	end

	return (0) -- sp_help


GO
*/
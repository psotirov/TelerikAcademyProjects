<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
      <html>
        <body>
          <h2>Students data</h2>
          <table border="1">
            <tr bgcolor="#9acd32">
              <th>name</th>
              <th>email</th>
              <th>course</th>
              <th>specialty</th>
              <th>facultynumber</th>
              <th>exams</th>
            </tr>
            <xsl:for-each select="students/student">
              <tr></tr>
              <tr>
                <td>
                  <xsl:value-of select="name"/>
                </td>
                <td>
                  <xsl:value-of select="email"/>
                </td>
                <td>
                  <xsl:value-of select="course"/>
                </td>
                <td>
                  <xsl:value-of select="specialty"/>
                </td>
                <td>
                  <xsl:value-of select="facultynumber"/>
                </td>
                <td>
                  <xsl:for-each select="exams/exam">
                    <xsl:value-of select="examname"/>
                    <br/>
                  </xsl:for-each>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
